package codeday.qrnbar;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.URI;
import java.util.ArrayList;
import java.util.List;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.app.Activity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.ArrayAdapter;
import android.widget.GridView;

public class pullScoreboard extends Activity implements OnClickListener {
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
        setContentView(R.layout.scoreboard);
        GridView gridView = (GridView) findViewById(R.id.scoreboardGrid);
		ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, pullScores());
		gridView.setAdapter(adapter);
	}
	private String[] pullScores(){
		connect("http://codeday.kicksgpt.com/androidData.php");
		List<String> vals = new ArrayList<String>();
		
		return (String[]) vals.toArray();
	}
	private static String convertStreamToString(InputStream is) {
        BufferedReader reader = new BufferedReader(new InputStreamReader(is));
        StringBuilder sb = new StringBuilder();
        String line = null;
        try {
            while ((line = reader.readLine()) != null) {
                sb.append(line + "\n");
            }
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            try {
                is.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        return sb.toString();
    }
	public static void connect(String url){
        HttpClient httpclient = new DefaultHttpClient();
        HttpGet httpget = new HttpGet(url);  
        HttpResponse response;
        try {
            response = httpclient.execute(httpget);
            Log.i("Praeda",response.getStatusLine().toString());
            HttpEntity entity = response.getEntity();
            if (entity != null) {
                // A Simple JSON Response Read
                InputStream instream = entity.getContent();
                
                //
                instream.close();
            }
        } catch (ClientProtocolException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } catch (IOException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
    }
	public void onClick(View v) {
		// TODO Auto-generated method stub
		
	}
}
