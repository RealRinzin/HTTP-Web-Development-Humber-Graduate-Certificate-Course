<?php
$host = 'mysql';
$db   = 'banana_counter';
$user = 'rinzin';      
$pass = 'password';          

$conn = mysqli_connect($host, $user, $pass, $db);

if (!$conn) {
    die(json_encode(['error' => 'Connection failed: ' . mysqli_connect_error()]));
}
