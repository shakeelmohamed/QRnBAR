<?php
//These can be passed to the web service, unused right now.
$geoCoords = $_GET['geoCoords']; //Comma seperated long/lat
$accuracy = $_GET['accuracy']; //Accuracy within meters

$url = 'https://graph.facebook.com/oauth/access_token?grant_type=client_credentials&client_id=195520880501852&client_secret=0633299c9c91fd0376431888e491d1ca';
$token = file_get_contents($url);
$token = preg_replace('/access_token=/', '', $token);
$graphURL = "https://graph.facebook.com/search?type=place&distance=".$accuracy."&center=".$geoCoords."&access_token=".$token;
$graphResponse = file_get_contents($graphURL);
$json = json_decode($graphResponse,true);
$json = $json['data'];
foreach ($json as $key => $value) {
	foreach ($value as $k => $v) {		
		switch($k){
			case 'name':
				echo $v .' |';
			break;
			case 'id':
				echo $v .' <br />';
			break;
		}
	}
}
?>