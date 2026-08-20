<?php
session_start();
if (isset($_SESSION['username'])) {
    header("Location:dashboard.php");
}
// Variables
$borderColor = "";
$textColor = "";
$invalidLogin = "";
$formValidation = false;

if (count($_POST) > 0) {
    // Login Credential
    $username = "rinzin";
    $password = "password";

    // Check the username and password

    if ($_POST['username'] == $username && $_POST["password"] == $password) {
        $_SESSION["username"] = $_POST["username"];
        // $invalidLogin = "<p class=$textColor >Invalid Credential</p>";
        header("Location:dashboard.php");
    } else {

        $borderColor = "border-red-600";
        $textColor = "text-red-600";
        $invalidLogin = "<p class=$textColor >Invalid Credential</p>";
    }
}
?>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login with Session</title>
</head>

<body>
    <main class="flex justify-center my-20">
        <form action="" method="post" name="loginForm" class="border shadow-md rounded-lg p-10 ">
            <h1 class="font-extrabold text-gray-700 my-4">User Login</h1>
            <div class="flex flex-col gap-2 my-4">
                <label for="username" class="text-sm text-gray-500 font-medium">Username</label>
                <input type="text" name="username" id="username" placeholder="Username" class="border rounded-md p-2 <?php if (!$formValidation) echo $borderColor; ?>">
            </div>
            <div class="flex flex-col gap-2 my-4">

                <label for="password" class="text-sm text-gray-500 font-medium">Password</label>
                <input type="password" name="password" id="password" placeholder="Password" class="border rounded-md p-2  <?php if (!$formValidation) echo $borderColor; ?>">
            </div>
            <?php
            if (!$formValidation) echo $invalidLogin;
            ?>
            <button type="submit" name="submit" class="rounded border-0 bg-blue-600 w-full text-white py-2">Login</button>
            <div class="my-2">
                <p class="text-sm text-gray-500">Use this credential for login</p>
                <p class="text-gray-600">Username : rinzin</p>
                <p class="text-gray-600">Password : password</p>
            </div>
        </form>
    </main>
    <script src="https://cdn.tailwindcss.com"></script>
    <script src="https://cdn.jsdelivr.net/npm/tailwindcss@4.3.1/dist/lib.min.js"></script>
</body>

</html>