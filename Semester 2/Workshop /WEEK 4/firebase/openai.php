<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <?php
    $data = array(
        'model' => 'gpt-5.4-nano',
        'messages' => [
            [
                'role' => 'user',
                'content' => 'Tell me a dad joke'
            ]
        ],
        // 'prompt' => 'give me 10 best dad jokes',
        'temperature' => 2 ,
        // 'top_p' => .3,
        // 'max_tokens' => 100,
    );

    $header = array(
        'Content-Type:application/json',
    );

    // Curl
    $curl = curl_init();
    curl_setopt($curl, CURLOPT_URL, 'https://api.openai.com/v1/chat/completions');
    curl_setopt($curl, CURLOPT_POST, true);
    curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($curl, CURLOPT_POSTFIELDS, json_encode($data));
    curl_setopt($curl, CURLOPT_HTTPHEADER, $header);

    $res = curl_exec($curl);
    curl_close($curl);
    print_r($res);
    // Decode JSON into PHP array
    // $joke = json_decode($res, true);
    // print_r($joke['choices'][0]['text']);
    // Get just the generated text
    // echo $joke['choices'][0]['text'];
    ?>
</body>

</html>