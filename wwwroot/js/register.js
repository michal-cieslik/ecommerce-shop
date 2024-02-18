document.getElementById('registerForm').addEventListener('submit', function (event) {
    event.preventDefault();
    const email = document.getElementById('emailRegister').value;
    const password = document.getElementById('passwordRegister').value;

    const userDetails = {
        email: email,
        password: password
    };

    const requestOptions = {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(userDetails)
    };

    fetch(`register`, requestOptions)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            if (response.status === 204 || response.status === 200) {
                alert("Your account has been created successfully");
                window.location.href = '/index.html';
                return null;
            }
            return response.json();
        })
        .then(data => {
            if (data !== null) {
                console.log("Server response: ", data);
            }
        })
        .catch(error => {
            console.error("Error while sending the request:", error);
        });
});