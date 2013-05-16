<?php
	$projectName = "QRnBAR";
	$scoreBoardURL = 'http://raveradar.com/codedaysvc.svc/GetScoreboard';
?>
<head>
	<title>QRnBAR - Scan codes with your friends!</title>
	<link href="bootstrap/css/bootstrap.css" rel="stylesheet">
	<link rel="" href="favicon.ico">
	<style>
		#main {
			padding: 20px 50px;
		}
		#scoreTitle {
			color: #0066FF;
			font-size: 30px;
			padding: 25px 25px;
		}
		.scoreEntry {
			color: #E62E00;
			padding: 10px;
			font-size: 24px;
			list-style-type: none;
		}
		#scoreBoardContainer {
			margin-left: auto;
			margin-right: auto;
			width: 950px;
		}
		#scoreBoardTable{
			margin: 40 40;
		}
		.scoreHeader {
			color: #1177FF;
			/*width: 65px;*/
			font-size: 16px;
			font-weight: bold;
			list-style-type: none;
			border-bottom: thin solid #1177FF;
		}
		.scoreHeader span{
			width: auto;
			padding-right: 64px;
		}
		.scoreData {
			padding-right: 64px;
			display: table-cell;
		}
		h1 {margin: 50 0 0 100;}
		p {margin: 10 500 0 130;}
	</style>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
	<script>
	function pullJSON(){
		var queryURL = 'select * from json where url="<?php echo $scoreBoardURL; ?>"';
		$.ajax({
			url: 'http://query.yahooapis.com/v1/public/yql', //Using Yahoo's YQL to do cross-domain requests
			data: {
				q: queryURL, //set the URL here
				format: 'json'
			},
			dataType: 'JSON',
			success: function(data){
				var response = data.query.results.json;
				var count = 0;
				
				var htmlOutput = "";
				htmlOutput += "<tr class='scoreHeader'>";
				htmlOutput += "<td>Place</td>";
				htmlOutput += "<td>Nickname</td>";
				htmlOutput += "<td>Score</td>";
				htmlOutput += "<td>Scans</td>";
				htmlOutput += "<td>Last Updated</td>";
				htmlOutput += "</tr>";
				
				for(var i in response){
					var b = response[i];
					for(var index in b){
						var item = b[index];
						count ++; //This should be placed where it can count up the number of entried pulled in from the database
						htmlOutput += '<tr id="'+item.ID+'" class="scoreEntry">';
							htmlOutput += '<td class="scoreData">'+item.Position+' </td>';
							htmlOutput += '<td class="scoreData">'+item.Nickname+' </td>';
							htmlOutput += '<td class="scoreData">'+item.Score+' </td>';
							htmlOutput += '<td class="scoreData">'+item.Scans+' </td>';
							htmlOutput += '<td class="scoreData">'+ getTimeSinceNowStr(parseTime(item.LastUpdated))+'</td>';
						htmlOutput += '</tr>';
					}
				}
				if(htmlOutput.length>0){
					$('#scoreBoardTable').html(htmlOutput);
				}
			}
		});
	}
	function pullJSONsexy(){
		var queryURL = 'select * from json where url="<?php echo $scoreBoardURL; ?>"';
		$.ajax({
			url: 'http://query.yahooapis.com/v1/public/yql', //Using Yahoo's YQL to do cross-domain requests
			data: {
				q: queryURL, //set the URL here
				format: 'json'
			},
			dataType: 'JSON',
			success: function(data){
				var response = data.query.results.json;
				var count = 0;
				
				var htmlOutput = "";
				htmlOutput += "<li class='scoreHeader'>";
					htmlOutput += "<span>Place</span>";
					htmlOutput += "<span>Nickname</span>";
					htmlOutput += "<span>Score</span>";
					htmlOutput += "<span>Scans</span>";
					htmlOutput += "<span>Last Updated</span>";
				htmlOutput += "</li>";
				
				for(var i in response){
					var b = response[i];
					for(var index in b){
						var item = b[index];
						count ++; //This should be placed where it can count up the number of entried pulled in from the database
						htmlOutput += '<li id="'+item.ID+'" class="scoreEntry">';
							htmlOutput += '<span class="scoreData_position">'+item.Position+' </span>';
							htmlOutput += '<span class="scoreData_nickname">'+item.Nickname+' </span>';
							htmlOutput += '<span class="scoreData_score">'+item.Score+' </span>';
							htmlOutput += '<span class="scoreData_scans">'+item.Scans+' </span>';
							htmlOutput += '<span class="scoreData_time">'+ getTimeSinceNowStr(parseTime(item.LastUpdated))+'</span>';
						htmlOutput += '</li>';
					}
				}
				if(htmlOutput.length>0){
					$('#scoreBoardTableSexy').html(htmlOutput);
					var listOfSpans = ['position', 'nickname', 'score', 'scans', 'time'];
					for(var s in listOfSpans){
						fixSpanWidth(listOfSpans[s]);
					}
				}
			}
		});
	}
	function fixSpanWidth(className){
		//This doesn't seem to work at all
		className = '.scoreData_'+className;
		var max = 0;
		$(className).each(function(){
			if(max < $(this).width()){
				max = $(this).width();
			}
		});
		$(className).each(function(){
			$(this).width(max);
		});
	}
	function getTimeSinceNowStr(from){
		var today = new Date();
		var ms = today - from;
		
		var msg;
		var days = Math.floor(ms / (1000 * 60 * 60 * 24));
		var hours = Math.floor(ms / (1000 * 60 * 60));
		var mins = Math.floor(ms / (1000 * 60));
		var secs = Math.floor(ms / (1000));
		
		// Get a string that represents how much time has passed
		if ( secs > 0 ) {
			msg = secs + " Second" + (secs > 1 ? "s" : "");
			if (mins > 0) {
				msg = mins + " Minute" + (mins > 1 ? "s" : "");
				if(hours > 0) {
					msg = hours + " Hour" + (hours > 1 ? "s" : "");
					if(days >  0) {
						msg = days + " Day" + (days > 1 ? "s" : "");
					}
				}
			}
		}
		else {
			//msg = "Just Now";
			return "Just Now";
		}
		return msg + " ago.";
	}
	function parseTime(input){
		input = input.replace(/Date(.)*?/, /$1/);
		input = input.replace(/(\(|\))?/g, "");
		input = input.replace(/(\/|\\)?/g, "");
		input = new Date(parseInt(input));
		return input;
	}
	function fixMonth(input){
		input++;
		switch(input){
			case 1:
				return 'Jan';
			case 2:
				return 'Feb';
			case 3:
				return 'Mar';
			case 4:
				return 'Apr';
			case 5:
				return 'May';
			case 6:
				return 'Jun';
			case 7:
				return 'Jul';
			case 8:
				return 'Aug';
			case 9:
				return 'Sep';
			case 10:
				return 'Oct';
			case 11:
				return 'Nov';
			case 12:
				return 'Dec';
		}
	}
	function fixTime(hrs, mins){
		if(hrs >= 12)
			return hrs-12+":"+mins+" pm";
		if(hrs==0)
			hrs = 12;
		return hrs+":"+mins+" am";
	}
	$(document).ready(function(){
		pullJSON();
		//pullJSONsexy(); not working
		window.setInterval(function(){
			pullJSON();
		}, 1000);
	});
	</script>
</head>
<div class="navbar navbar-fixed-top">
	<div class="navbar-inner">
	    <div class="container">
			<a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
	            <span class="icon-bar"></span>
	            <span class="icon-bar"></span>
	            <span class="icon-bar"></span>
			</a>
			<a class="brand" href="index.php"><?php echo $projectName; ?></a>
			<div class="nav-collapse">
				<ul class="nav">
					<li class="active"><a href="index.php">Home</a></li>
					<li class="inactive"><a href="about.php">About</a></li>
            	</ul>
			</div>
		</div>
	</div>
	<h1>Leaderboard:</h1>
	<div id="scoreBoardContainer">
		<table id="scoreBoardTable">
		</table>
		<ul id="scoreBoardTableSexy">
		</ul>
	</div>
</div>