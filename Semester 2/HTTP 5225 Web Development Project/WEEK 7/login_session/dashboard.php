<?php
session_start();
/**
 * Check if a session exists, and redirect to the login page if no session exists.
 * HINT: How do we start sessions and check session variables in PHP?
 */

if (!isset($_SESSION['username'])) {
    header("Location:index.php");
}
// Unset all session variables

if (isset($_POST['submit'])) {
    session_unset();
    session_destroy();
    header("Location: index.php");
    exit;
}

?>
<!DOCTYPE html>
<html>

<head></head>

<body>
    <h1>Dashboard</h1>

    <div>
        <p>Welcome, <?php echo $_SESSION['username'] ?>
        <form action="#" method="post">
            <button type="submit" name="submit">Logout</button>
        </form>
        </p>
    </div>

</body>

</html>