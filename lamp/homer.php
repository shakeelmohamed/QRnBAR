<!DOCTYPE html>   
<html lang="en">
<head>
	<title>Cool Boostrap Bro!</title>
	<meta name="description" content="My Boostrappin' test!">
	<link rel="stylesheet" href="/bootstrap/css/bootstrap.css">
	<style type="text/css">
		.socials {  
			padding: 10px;  
		} 
		body {
        padding-top: 60px;
        padding-bottom: 40px;
      }
	</style>
</head>
<body>
	<div id="fb-root"></div>  
	<script> //Facebook integration
		(function(d, s, id) {  
		  var js, fjs = d.getElementsByTagName(s)[0];  
		  if (d.getElementById(id)) return;  
		  js = d.createElement(s); js.id = id;  
		  js.src = "//connect.facebook.net/en_GB/all.js#xfbml=1";  
		  fjs.parentNode.insertBefore(js, fjs);  
		}(document, 'script', 'facebook-jssdk'));
	</script> 
	<div class="navbar navbar-fixed-top">  
  		<div class="navbar-inner">  
    		<div class="container">
    			<ul class="nav">  
					<li class="active">  
						<a class="brand" href="#">QRnBAR</a>  
					</li>  
					<li><a href="#">About</a></li>
				</ul>
				<ul class="nav pull-right">
					<li class="dropdown">
						<a href="#" class="dropdown-toggle" data-toggle="dropdown">Social
							<b class="caret"></b>
						</a>
						<ul class="dropdown-menu">
							<li class="socials"><!-- Place this tag where you want the +1 button to render -->
								<g:plusone annotation="inline" width="150"></g:plusone>
							</li>
							<li class="socials">
								<div class="fb-like" data-send="false" data-width="150" data-show-faces="true"></div>
							</li>
							<li class="socials">
								<a href="https://twitter.com/share" class="twitter-share-button">Tweet</a>
								<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0];if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src="//platform.twitter.com/widgets.js";fjs.parentNode.insertBefore(js,fjs);}}(document,"script","twitter-wjs");</script>
							</li>
						</ul>
					</li>
				</ul>
			</div>
		</div>
	</div>
	<div id="mainwrapper">
		<div class="container">
			<div class="hero-unit">
				<h1>QRnBAR - Leaderboard</h1>
				<p>These are the top scores in our game.</p>
				<p>If you want to be on this list, get out there and scan some codes!</p>
				<a class="btn btn-primary btn-large">Get it for Android &raquo;</a>
			</div>
			<br />
			<div class="row">
				<div class="span2" />
				<div class="span8">
					<table class="table table-striped">  
				        <thead>  
							<tr>  
								<th>Rank</th>  
								<th>Nickname</th>  
								<th>Scans</th>  
								<th>Points</th>
								<th>Last Updated</th>
							</tr>  
				        </thead>  
				        <tbody>  
							<tr>  
								<td>1</td>  
								<td>A </td>  
								<td>1</td>  
								<td>99</td>
								<td>now</td>
							</tr>  
							<tr>  
								<td>2</td>  
								<td>B</td>  
								<td>1</td>  
								<td>40</td>
								<td>now</td>
							</tr>  
							<tr>  
								<td>3</td>  
								<td>C</td>  
								<td>1</td>  
								<td>15</td>
								<td>now</td>
							</tr>  
				        </tbody>  
				      </table>  
				<div class="span2" />
				</div>
			</div>
		</div>
	</div> <!--end mainwrapper-->
	<div id="inactive" style="display:none;">
		sodfhsoidfhsoifhfh
	</div>
	<script src="bootstrap/docs/assets/js/jquery.js"></script>  
	<script src="bootstrap/docs/assets/js/bootstrap-dropdown.js"></script>
	<script type="text/javascript"> //Google+ integration
	  (function() {  
	    var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;  
	    po.src = 'https://apis.google.com/js/plusone.js';  
	    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);  
	  })();  
	</script>

	<script>
	//My testing js, I want to have all the pages load on one page... 
	/*
	$('.nav').children('.active').children('a').click(function(){
		$('.nav').children().each(function(){
			if($(this).hasClass('inactive')){
				$('#mainwrapper').hide();
			}
		});
		$('#inactive').show();
	}); 
	*/
	</script>
</body>
</html>