<?php
session_start();
$pageTitle = "Login";
require_once(__DIR__ . '/config/db.php');

if (isset($_SESSION['username'])) {
    header("Location:dashboard.php");
}
$error_msg = "";
if (count($_POST) > 0) {
    // 1. Capture user inputs securely from the form
    $email = $_POST['email'] ?? '';
    $password = $_POST['password'] ?? '';

    if (!empty($email) && !empty($password)) {
        // 2. Prepare the statement using universal SQL syntax
        $query_prepared = $conn->prepare("SELECT id,username,email, password FROM users WHERE email = ?");

        // 3. Bind the email parameter ("s" means string)
        $query_prepared->bind_param("s", $email);

        // 4. Run the query on the database
        $query_prepared->execute();

        // 5. Extract the matching row
        $result = $query_prepared->get_result();
        $user = $result->fetch_assoc();

        // 6. Verify password (works with standard PHP password_hash)
        if ($user && password_verify($password, $user['password'])) {
            // Login success: Save user details to session
            $_SESSION['user_id'] = $user['id'];
            $_SESSION['username'] = $user['username'];
            // Redirect to dashboard or homepage
            header("Location: dashboard.php");
            exit;
        } else {
            $error_msg = "Invalid email address or password.";
        }
    } else {
        $error_msg = "Please fill in all fields.";
    }
}
include "common/simple_header.php";

?>

<main class="min-h-screen">
    <div class="grid grid-cols-1 md:grid-cols-2">
        <div class="flex flex-col gap-10 mx-auto my-auto w-1/2">
            <h1 class="text-2xl font-bold text-left">The Dawn & Dust Post</h1>
            <p class="text-xl font-bold">
                The role of a great newspaper is to hold power to account — quietly, relentlessly, and with the reader always in mind."
            </p>
            <p class="text-xs text-gray-500">© 2026 The Meridian Media Company</p>
        </div>
        <div class="bg-gray-50 flex items-center min-h-screen">
            <div class="w-1/2 mx-auto">
                <div class="mx-auto flex flex-col gap-4">
                    <h1 class="text-2xl font-bold my-10">The Dawn & Dust Post</h1>
                    <p class="text-red-800 text-sm font-medium"> SUBSCRIBE SIGN IN</p>
                    <p class="text-gray-900 font-extrabold text-3xl">Welcome Back.</p>
                    <p class="text-gray-700">Not a subscriber? <a href="" class="text-red-800 underline font-medium">Create an account</a></p>
                </div>
                <!-- Login -->

                <form action="" method="post" class="flex flex-col gap-6 py-6">
                    <?php if (!empty($error_msg)): ?>
                        <div class="bg-red-100 border border-red-400 text-red-700 px-4 py-2 rounded text-sm my-2">
                            <?php echo htmlspecialchars($error_msg); ?>
                        </div>
                    <?php endif; ?>
                    <div class="flex flex-col gap-2">
                        <label for="email" class="text-gray-600 text-xs font-bold">EMAIL ADDRESS</label>
                        <input type="text" name="email" id="email" class="border border-gray-200 p-2">
                    </div>
                    <div class="flex flex-col gap-2">
                        <label for="password" class="text-gray-600 text-xs font-bold">PASSWORD</label>
                        <input type="password" name="password" id="password" class="border border-gray-200 p-2">
                    </div>
                    <div class="flex gap-2">
                        <input type="checkbox" class="accent-blue-600 h-5 w-5">
                        <p class="text-xs">Keep me signed in on this device</p>
                    </div>
                    <button class="text-center p-2 bg-gray-900 text-white font-medium text-sm"> SIGN IN</button>
                </form>
            </div>
        </div>
    </div>
</main>
<?php include "common/footer.php"; ?>