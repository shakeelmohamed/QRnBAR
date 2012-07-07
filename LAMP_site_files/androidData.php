<?php
	$scoreBoardURL = 'http://raveradar.com/codedaysvc.svc/GetScoreboard';
?>
<head>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
	<script>
	function pullJSON(){
		var queryURL = 'select * from json where url="<?php echo $scoreBoardURL; ?>"';
		jQuery.ajax({
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
				for(var i in response){
					var b = response[i];
					for(var index in b){
						var item = b[index];
						count ++; //This should be placed where it can count up the number of entried pulled in from the database
						/*htmlOutput += '<li id="'+item.ID+'" class="scoreEntry">';
							htmlOutput += '<span class="playerPosition">'+item.Position+' </span>';
							htmlOutput += '<span class="playerNickname">'+item.Nickname+' </span>';
							htmlOutput += '<span class="playerScore">'+item.Score+' </span>';
							htmlOutput += '<span class="playerScans">'+item.Scans+' </span>';
							htmlOutput += '<span class="playerLastUpdated">'+parseTime(item.LastUpdated)+' </span>';
						htmlOutput += '</li>';*/
						htmlOutput += (item.ID+"|*|"+item.Position+"|*|"+item.Nickname+"|*|"+item.Score+"|*|"+item.Scans+"|*|"+getTimeSinceNowStr(parseTime(item.LastUpdated))+'|*|');
						//Change the
					}
				}
				if(htmlOutput.length>0){
					jQuery(htmlOutput).appendTo('#scoreBoardDiv');
				}
			}
		});
	}
	function parseTime(input){
		input = input.replace(/Date(.)*?/, /$1/);
		input = input.replace(/(\(|\))?/g, "");
		input = input.replace(/(\/|\\)?/g, "");
		input = new Date(parseInt(input));
		return input;
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
			msg = secs + " second" + (secs > 1 ? "s" : "");
			if (mins > 0) {
				msg = mins + " minute" + (mins > 1 ? "s" : "");
				if(hours > 0) {
					msg = hours + " hour" + (hours > 1 ? "s" : "");
					if(days >  0) {
						msg = days + " day" + (days > 1 ? "s" : "");
					}
				}
			}
		}
		
		//return String(fixMonth(parseInt(input.getMonth()))+" "+input.getDate()+", "+input.getFullYear()+" "+fixTime(parseInt(input.getHours()), parseInt(input.getMinutes())));
		return msg + " ago.";
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
	jQuery(document).ready(function(){
		pullJSON();
	});
	</script>
</head>
	<ul id="scoreBoardDiv">
		<li id="scoreHeader">Scoreboard:</li>
		<li id="noScores">Sorry nobody has played the game yet...</li>
	</ul>