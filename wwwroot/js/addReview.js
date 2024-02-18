document.addEventListener('DOMContentLoaded', function () {
    let addReviewBox = document.getElementById('addReview');
    if (localStorage.getItem('isLoggedIn') == "false") {
        let needLogin = document.createElement('p');
        needLogin.textContent = "You must be logged in to add review";
        addReviewBox.appendChild(needLogin);
    }
    else {
        let rating = document.createElement('input');
        rating.type = 'number';
        rating.max = 5;
        rating.min = 0;
        rating.placeholder = 'Add rating (0-5)';
        rating.id = 'productRating';


        let context = document.createElement('textarea');
        context.type = "text";
        context.id = 'productContext';
        context.maxLength = "255";
        context.placeholder = 'Add review';

        let submitButton = document.createElement('input');
        submitButton.type = 'button';
        submitButton.className = 'btn-register';
        submitButton.value = 'Add';
        submitButton.id = 'submitButton';
        submitButton.addEventListener('click', addReview)

        addReviewBox.appendChild(rating);
        addReviewBox.appendChild(context);
        addReviewBox.appendChild(submitButton);
    }
});

function addReview() {
    let rating = document.getElementById('productRating');
    let productContext = document.getElementById('productContext');
    let addReviewBox = document.getElementById('addReview'); 
    let productId = new URLSearchParams(document.location.search).get('productId');
    
    Array.from(addReviewBox.getElementsByClassName('error')).forEach(item => {
        addReviewBox.removeChild(item);
    });


    if (rating.value > 5 || rating.value < 0 || rating.value == null || rating.value == "") {
        let error = document.createElement('p');
        error.className = 'error';
        error.textContent = "Wrong rating value";
        addReviewBox.appendChild(error);
        return false;
    }

    if (productContext.length > 255 || productContext.value == "" || productContext == null) {
        let error = document.createElement('p');
        error.className = 'error';
        error.textContent = "Wrong context value";
        addReviewBox.appendChild(error);
        return false;
    }

    fetch('/api/Review', {
        method: 'POST',
        headers: {
            'Authorization': `Bearer ${localStorage.getItem('token')}`,
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            "productId": productId,
            "userId": `${localStorage.getItem('token')}`,
            "comment": productContext.value,
            "rating": rating.value
        }),
    })
        .then(response => {
            if (response.status == 201 || response.status == 200) {
                let success = document.createElement('p');
                success.className = 'success';
                success.textContent = "Added!"

                addReviewBox.removeChild(productContext);
                addReviewBox.removeChild(rating);
                addReviewBox.removeChild(document.getElementById('submitButton'));
                addReviewBox.appendChild(success);

                alert("Added!");
                window.location.reload();
            }
            return response.json();
        })
        .then(response => {
            if (response.error) {
                alert(`Error: ${response.error}`)
            }
        })
}