package codeday.qrnbar;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.URI;
import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.List;

import org.apache.http.HttpConnection;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.client.methods.HttpPut;
import org.apache.http.client.utils.URLEncodedUtils;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONArray;
import org.json.JSONObject;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.net.Uri;
import android.os.Bundle;
import android.telephony.TelephonyManager;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup.LayoutParams;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

public class QrnbarActivity extends Activity implements OnClickListener {    
    private String imei = "";
    private String phoneNumber = "";
    private String Nickname = "";
	@Override
    public void onCreate(Bundle savedInstanceState) {
		TelephonyManager t = (TelephonyManager)getSystemService(Context.TELEPHONY_SERVICE);
        this.imei = t.getDeviceId();
        this.phoneNumber = t.getLine1Number();
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        
        
        TextView tv = (TextView)findViewById(R.id.nicknameSpacer);
        tv.setVisibility(View.GONE);
        
        Button scoreBoard = (Button)findViewById(R.id.viewScoreboard);
        scoreBoard.setOnClickListener(this);
        Button saveUser = (Button)findViewById(R.id.saveNickname);
        saveUser.setOnClickListener(this);
        Button startScan = (Button)findViewById(R.id.startScan);
    	startScan.setVisibility(View.GONE);
    	LinearLayout dashboard = (LinearLayout)findViewById(R.id.dashboard);
    	dashboard.setVisibility(View.GONE);
        try {
			Nickname = getPlayer(this.imei).replace("\"", "").replace("\n", "");
			if(Nickname.length()==0 || Nickname.equals(null)){ //If no nickname is associated w/ the IMEI
				//Show the field & button to allow user to add a nickname (and validate it)
				saveUser.setVisibility(View.VISIBLE);
				startScan.setVisibility(View.GONE);
			}
			else{
				//Show the user's nickname somewhere on the screen & their point total
				startScan.setVisibility(0);
				LinearLayout nickField = (LinearLayout)findViewById(R.id.nicknameLayout);
				nickField.setVisibility(View.GONE);
				startScan = (Button)findViewById(R.id.startScan);
		        startScan.setText("Scan a code!");
		        startScan.setOnClickListener(this);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
    }
    public void onClick(View v){
    	switch(v.getId()){
	    	case R.id.startScan:
	    		doScan();
	    		break;
	    	case R.id.saveNickname:
				try {
					EditText sdf = (EditText)findViewById(R.id.nicknameField);
					this.Nickname = sdf.getText().toString();
					String resp = setupPlayer(this.imei, this.Nickname).replace("\n", "");
					TextView tex = (TextView)findViewById(R.id.viewScoreboard);
					//if(resp.toLowerCase().equals("true")){
						Button nick = (Button)findViewById(R.id.nicknameLayout);
				    	nick.setVisibility(View.GONE);
				    	nick = (Button)findViewById(R.id.startScan);
				    	nick.setVisibility(View.VISIBLE);
					//}
				} catch (Exception e) {
					e.printStackTrace();
				}
	    		break;
	    	case R.id.viewScoreboard:
	    		Intent browserIntent = new Intent(Intent.ACTION_VIEW, Uri.parse("http://www.codeday.kicksgpt.com"));
	    		startActivity(browserIntent);
	    		/*
	    		Intent scoreboardView = new Intent(this, pullScoreboard.class);
	    		this.startActivity(scoreboardView);*/
	    		break;
    	}
    }
    public void doScan(){
    	IntentIntegrator.initiateScan(this);
    }
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
    	switch(requestCode) {
	    	case IntentIntegrator.REQUEST_CODE: {
		    	if (resultCode != RESULT_CANCELED) {
			    	IntentResult scanResult = IntentIntegrator.parseActivityResult(requestCode, resultCode, data);
			    	if (scanResult != null) {
				    	String upc = scanResult.getContents();
				    	//put whatever you want to do with the code here
				    	//This will push the code to the ui
				    	TextView tv = new TextView(this);
				    	String postme = "";
				    	postme += "The code's message was : "+ upc + "\n";
				    	tv = (TextView) findViewById(R.id.scanPageText); //My doesn't make a new view
				    	Button startScan = (Button)findViewById(R.id.startScan);
				    	startScan.setVisibility(View.GONE); //Hides the button if there's a code found
				    	if(haveInternet(this)){
				    		try {
								//postme += 
								String suxess = getResponse(this.imei, upc);
								postme += suxess;
								if(suxess.toLowerCase().equals("true")){ //There could be anewline
									
								}
								else {
									//postme += "Sorry that code was already used!";
								}
							} catch (Exception e) {
								e.printStackTrace();
							}
				    	}
				    	else {
				    		postme += "No data connection!\nThis app will be useless until you setup a data or wifi connection.";
				    	}
				    	tv.setText(postme);
			    	}
		    	}
		    	break;
    		}
    	}
	}
    public static boolean haveInternet(Context c) {
        NetworkInfo info = (NetworkInfo) ((ConnectivityManager) c.getSystemService(Context.CONNECTIVITY_SERVICE)).getActiveNetworkInfo();
        if (info == null || !info.isConnected()) {
            return false;
        }
        if (info.isRoaming()) {
            // here is the roaming option you can change it if you want to
            // disable internet while roaming, just return false
            return false;
        }
        return true;
    }
    public static String getResponse(String imei, String code) throws Exception {
    	String ret = "";
    	BufferedReader in = null;
        try {
            HttpClient client = new DefaultHttpClient();
            HttpGet request = new HttpGet();
            String url = "http://raveradar.com/CodeDaySvc.svc/Scan?imei=" + imei + "&code=" + code + "&points=" + getCodeValue(code);
            request.setURI(new URI(url));
            HttpResponse response = client.execute(request);
            in = new BufferedReader(new InputStreamReader(response.getEntity().getContent()));
            StringBuffer sb = new StringBuffer("");
            String line = "";
            String NL = System.getProperty("line.separator");
            while ((line = in.readLine()) != null) {
                sb.append(line + NL);
            }
            in.close();
            String page = sb.toString();
            ret = page;
            } finally {
            if (in != null) {
                try {
                    in.close();
                    } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    	return ret;
    }
    public static String getPlayer(String imei) throws Exception {
    	String ret = "";
    	BufferedReader in = null;
        try {
            HttpClient client = new DefaultHttpClient();
            HttpGet request = new HttpGet();
            String url = "http://raveradar.com/CodeDaySvc.svc/GetPlayer/" + imei; //This isn't pulling in the nickname
            request.setURI(new URI(url));
            HttpResponse response = client.execute(request);
            in = new BufferedReader(new InputStreamReader(response.getEntity().getContent()));
            StringBuffer sb = new StringBuffer("");
            String line = "";
            String NL = System.getProperty("line.separator");
            while ((line = in.readLine()) != null) {
                sb.append(line + NL);
            }
            in.close();
            String page = sb.toString();
            ret = page;
            //return ret.replace("\"", "");
	            /*if(!page.toLowerCase().contains("nickname")){
	            	return null;
	            }
	            else{
	            	JSONObject myjson = new JSONObject(page);
	            	//JSONArray the_json_array = myjson.getJSONArray("nickname");
	            	return myjson.getJSONObject("nickname").toString();
	            }*/
            } finally {
            if (in != null) {
                try {
                    in.close();
                    } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    	return ret.replace("\"", "");
    }
    public static String setupPlayer(String imei, String nickname) throws Exception {
    	String ret = "";
    	BufferedReader in = null;
        try {
            HttpClient client = new DefaultHttpClient();
            HttpGet request = new HttpGet();
            String url = "http://raveradar.com/CodeDaySvc.svc/SetupPlayer?imei=" + imei + "&nickname=" + nickname;
            request.setURI(new URI(url));
            HttpResponse response = client.execute(request);
            in = new BufferedReader(new InputStreamReader(response.getEntity().getContent()));
            StringBuffer sb = new StringBuffer("");
            String line = "";
            String NL = System.getProperty("line.separator");
            while ((line = in.readLine()) != null) {
                sb.append(line + NL);
            }
            in.close();
            String page = sb.toString();
            ret = page;
            } finally {
            if (in != null) {
                try {
                    in.close();
                    } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    	return ret;
    }
    public static int getCodeValue(String code){
    	int value = 0;
    	char[] list = code.toCharArray();
    	for(char e : list){
    		value += (int)e;
    	}
    	return value%100;
    }
}