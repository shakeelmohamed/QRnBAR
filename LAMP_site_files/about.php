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
		#what, #what, #tech {
			padding: 40 40 0 40;
		}
		h1 {margin: 50 0 0 100;}
		p {margin: 10 500 0 130;}
	</style>
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
					<li class="inactive"><a href="index.php">Home</a></li>
					<li class="active"><a href="about.php">About</a></li>
            	</ul>
			</div>
		</div>
	</div>
	<h1>How we started:</h1>
	<div id="how">
		<p>QRnBAR began with the 3 members of our team (<a href="http://twitter.com/_Shakeel">Shakeel</a>, <a href="http://twitter.com/andrewcraswell">Andrew</a> &amp; <a href="http://twitter.com/sameezch">Sameez</a>) competing in a 30 hour programming competition (CodeDay MEGA) put on by <a href="http://studentrnd.org/">StudentRND</a> at <a href="http://thinkspace.com/">thinkspace</a> in Redmond, WA.</p>
		<p>All in all, we won first place in the mobile apps category against some very tough competition.</p>
		<p>
	</div>
	<h1>What it is:</h1>
	<div id="what">
		<p>QRnBAR is a mobile application, currently for Android, which allows you scan QR codes &amp; barcodes for a designated point value.</p>
		<p>What seperates us from most apps is that our registration process is literally one field: a nickname!</p>
		<p>Our homepage hosts a leaderboard which shows the top users of the app.</p>
	</div>
	<h1>Technologies we're using</h1>
	<div id="tech">
		<p>Microsoft SQL Server (for our data), WCF webservice (to access data), LAMP environment to host our website, Android mobile application (Java &amp; XML), jQuery &amp; ajax (parse JSON data from web service), ZXING API (to read barcodes/QR codes).</p>
	</div>
</div>