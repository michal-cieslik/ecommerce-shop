document.addEventListener('DOMContentLoaded', function () {
    fetch('/api/Product', {
        method: "GET"
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
            console.log(response.json());
        })
        .then(data => {
            const tableBody = document.getElementById('productsTable').querySelector('tbody');
            data.forEach(product => {
                const row = tableBody.insertRow();
                let link = document.createElement('a');
                link.href = `/product.html?productId=${product.id}`;
                link.textContent = product.name;
                link.className = "productLink"
                row.insertCell().appendChild(link);
                row.insertCell().textContent = product.description;
                row.insertCell().textContent = product.price;
            });
        })
        .catch(error => {
            console.error('Error:', error);
        });
});