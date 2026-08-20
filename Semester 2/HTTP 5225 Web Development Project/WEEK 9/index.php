<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>PHP Composer</title>
</head>

<body>
    <?php
    // Import the libraries
    use PHPMailer\PHPMailer\PHPMailer;
    use PHPMailer\PHPMailer\SMTP;
    use PHPMailer\PHPMailer\Exception;
    // Load all the dependency files
    require 'vendor/autoload.php';
    $mailer = new PHPMailer(true);

    // import env file
    // Check the empty form
    if (isset($_POST['send'])&&isset($_POST['message'])) {
       $message = $_POST['message'];
        // Send Mail
        try {
            // SMPT setting
            $mailer->SMTPDebug = 0;
            $mailer->isSMTP();
            $mailer->Host = "smtp.sendgrid.net";
            $mailer->SMTPAuth = true;
            $mailer->Username = constant("username");
            $mailer->Password = constant("password");
            $mailer->SMTPSecure = PHPMailer::ENCRYPTION_STARTTLS;
            $mailer->Port = 587;

            // Recepit
            $mailer->setFrom("disil89322@besteya.com", "Rinzin");
            $mailer->addAddress("ofp0z9knr4@ozsaip.com", "Rinzin");

            // Content body
            $mailer->isHTML(true);
            $mailer->Subject = "SMPT Mail ";
            $mailer->Body = $message;
            $mailer->AltBody = "Mailed";
            // Send
            $mailer->send();
            echo "<p style=color:green>Mail sent successfully </p>";
        } catch (Exception $e) {
            echo $mailer->ErrorInfo;
        }
    }
    ?>
    <form action="#" method="post">
        <p>Send a mail</p>
        <textarea name="message" id="message" placeholder="Your message"></textarea>
        <br>
        <button type="submit" name="send">Send Mail</button>
    </form>
</body>

</html>