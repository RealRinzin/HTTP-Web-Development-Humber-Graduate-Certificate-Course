<?php
// ============================================================
// Database connection configuration
// ============================================================
$host     = "mysql";
$username = "rinzin";
$password = "password";
$database = "cms_news_db";
// $port = "81";
// Create connection
$conn = mysqli_connect($host, $username, $password, $database);
// Check connection
if (!$conn) {
    die("<p style='color:red;'>Connection failed: " . mysqli_connect_error() . "</p>");
}
