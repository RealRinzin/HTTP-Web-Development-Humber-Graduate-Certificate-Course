<!DOCTYPE html>
<html>
<head>
<title>PHP Exercise 1: Links and Variables</title>
</head>
<body>
<h1>PHP Exercise 1: Links and Variables</h1>
<p>Use PHP echo and variables to output the
following link information:</p>
<hr>
<?php
$linkName = 'Codecademy';
$linkURL = 'https://www.codecademy.com/';
$linkImage =
'https://upload.wikimedia.org/wikipedia/commons/6/6c/Codecademy.svg';
$linkDescription = 'Learn to code interactively, for free.';
?>

<!-- Codecademy -->
<main>
    <h1><?php echo $linkName; ?></h1>
    <p><?php echo $linkDescription; ?></p>
    <img src="<?php echo $linkImage?>" alt="" width="200px">

    <a href="<?php echo $linkURL ?>" style="display: block;">Visit Codecademy</a>
</main>
</body>
</html>