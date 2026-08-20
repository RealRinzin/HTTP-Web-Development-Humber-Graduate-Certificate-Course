<?php 
$pageTitle = "Register";
include "common/simple_header.php";
?>

<main class="min-h-screen">
    <ul class="flex justify-between p-2 border-b border-b-gray-200">
        <li><a href="">The Dawn & Dust Post</a></li>
        <li class="text-xs text-gray-600">Already a member? <a href="/login.php" class="text-red-800 ">Sign In</a></li>
    </ul>
    <div class="w-1/3 mx-auto border border-gray-200 p-10 my-10 min-h-screen">
        <form action="">
            <h1 class="text-2xl font-bold py-1">Create your account</h1>
            <p class="text-sm text-gray-600">Takes less than a minute.</p>
            <div class="flex flex-col gap-6 my-6">
                <div class="flex gap-2">
                    <div class="sm:flex md:flex-col gap-2 w-full">
                        <label for="email" class="text-gray-600 text-xs font-bold">FIRST NAME</label>
                        <input type="text" name="email" id="email" class="border border-gray-200 p-2">
                    </div>
                    <div class="flex flex-col gap-2 w-full">
                        <label for="email" class="text-gray-600 text-xs font-bold">SECOND NAME</label>
                        <input type="text" name="email" id="email" class="border border-gray-200 p-2">
                    </div>
                </div>
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
                    <p class="text-xs text-gray-500">I agree to the <a href="" class="font-medium">Terms and Privacy Policies</a></p>
                </div>
                <button class="text-center p-2 bg-gray-900 text-white font-bold text-sm"> REGISTER</button>
            </div>
        </form>

    </div>
</main>
<?php include "common/footer.php"; ?>