document.addEventListener('DOMContentLoaded', function () {
    let productId = new URLSearchParams(document.location.search).get('productId');

    fetch(`/api/Product/${productId}`, {
        method: "GET"
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            let name = document.createElement('h3');
            let description = document.createElement('p');
            name.textContent = data.name;
            description.textContent = data.description;

            document.getElementById('productTitle').appendChild(name);
            document.getElementById('productDescription').appendChild(description);
            document.getElementById('productPrice').textContent = `Price: ${data.price}`;
        })
        .catch(error => {
            console.error('Error: ', error);
        });

    fetch(`/api/Review/Product/${productId}`, {
        method: "GET"
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            const reviewContainer = document.getElementById('reviewsContainer');
            if (data.length === 0) {
                let noReviews = document.createElement('p');
                noReviews.textContent = 'No reviews yet';
                reviewContainer.appendChild(noReviews);
            } else {
                data.forEach(review => {
                    let reviewBox = document.createElement('div');
                    reviewBox.classList.add('reviewItem')

                    let comment = document.createElement('p');
                    comment.textContent = review.comment;
                    let rating = document.createElement('p');
                    rating.textContent = `${review.rating}/10`;

                    reviewBox.appendChild(comment);
                    reviewBox.appendChild(rating);

                    reviewContainer.appendChild(reviewBox);
                });
            }
        })
        .catch(error => {
            console.error('Error:', error);
        });
});