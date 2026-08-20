<?php

/**
 * Lab 7 - APIs
 * Start by putting the URL for the API of your choice below.
 * Your API may require an API key. If the API takes GET requests, you can put
the API key as a URL parameter at the end of the URL.
 * If your API requires a POST request, you may need to modify the example code
to add a POST data parameter.
 * Whichever way, follow the API's documentation to help you out.
 */
// $url = "api.example.com"; // Replace with your API URL
$url = "https://jsonplaceholder.typicode.com/posts/1";
$ch = curl_init($url);
//The two lines below are to prevent SSL errors when using cURL locally - for SSL
// security reasons, do not include on a hosted site!
curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);
curl_setopt($ch, CURLOPT_SSL_VERIFYHOST, false);
curl_setopt($ch, CURLOPT_URL, $url);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
$result = curl_exec($ch);
if ($result == false) {
    echo curl_error($ch);
}
$result = json_decode($result, true);
?>
<!DOCTYPE html>
<html>

<body>
    <!-- Next, print some or all of your API's result to the page! -->
    <?php if (isset($result['title'])): ?>
        <p><strong>Post ID:</strong> <?php echo htmlspecialchars($result['id']); ?></p>
        <p><strong>User ID:</strong> <?php echo htmlspecialchars($result['userId']); ?></p>
        <p><strong>Title:</strong> <?php echo htmlspecialchars($result['title']); ?></p>
        <p><strong>Body:</strong> <?php echo htmlspecialchars($result['body']); ?></p>
    <?php else: ?>
        <p>Sorry, no data could be retrieved.</p>
    <?php endif; ?>
</body>

</html>