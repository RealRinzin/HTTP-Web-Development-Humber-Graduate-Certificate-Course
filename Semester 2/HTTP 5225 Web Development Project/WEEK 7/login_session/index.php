<?php
// Start the session
session_start();
if (isset($_SESSION['username'])) {
    header("Location:dashboard.php");
}
if(count($_POST) > 0)
{
    if(empty($_POST['username']) || empty($_POST['password']))
    {
        $isValid = false;
    }
    $validUsername = 'rinzin';
    $validPassword = 'password';

    /**
     * Check if the user inputted username and password match the correct user, using the code above to get you started.
     * Note that in a real application, we would not be comparing usernames and plaintext passwords against variable strings, but this is just for practice.
     * If the username and password is valid, set the session and redirect to the dashboard page. 
     * HINT: How do we start sessions and set session variables in PHP?
     */

    if($_POST['username'] == $validUsername && $_POST['password'] == $validPassword){
        $_SESSION["username"] = $_POST['username'];
        header("Location:dashboard.php");
    }else{
        echo "<span style='color:red'>Credential Failed</span>";
    }

}

?>

<!DOCTYPE html>
<html>
    <head></head>
    <body>
        <h1>Login</h1>

        <div>
            <form action="" method="post">
                <div>
                    <label for="username">Username</label>
                    <input type="text" id="username" name="username" required>
                </div>

                <div>
                    <label for="password">Password</label>
                    <input type="password" id="password" name="password" required>
                </div>

                <button type="submit">Submit</button>
            </form>
        </div>
    </body>
</html>