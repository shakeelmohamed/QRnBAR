<html>
<head>
	<script src="bootstrap/docs/assets/js/jquery.js"></script>  
	<script>
	//This is using terrible naming conventions, but it almost works
		$(document).ready(function() {
			$('#a_old').hide();
			$('#fillme').load('text.php #old');
			$('#a_new').click(function(){
				$(this).hide();
				$('#old').hide();
				$('#a_old').show();
				$('#fillme').load('text.php #new');
			});
			$('#a_old').click(function(){
				$(this).hide();
				$('#new').hide();
				$('#a_new').show();
				$('#fillme').load('text.php #old');
			});
		});
		
	</script>
</head>
<body>
	<a id="a_new" href="#new">Click me, I dare you.</a>
	<a id="a_old" href="#old">Click me, to undo.</a>
	<div id="fillme">
	</div>
</body>
</html>