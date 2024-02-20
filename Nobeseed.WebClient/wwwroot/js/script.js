fetch('https://localhost:7289/api/book')
    .then(response => {
        return response.json();
    })
    .then(data => {
        let dataContainer = document.getElementById('dataContainer');
        dataContainer.innerHTML = ''; // ������� ���������
        books = data.data;

        // ���������, �������� �� data ��������
        if (Array.isArray(books)) {
            books.forEach(item => {

                let properties = '';

                for (let key in item) {
                    properties += `<div class="book-card">
                        <a href="/Catalog/GetBook?id=${item.id}">
                            <p>${key}: ${item[key]}</p>
                        </a>
                    </div>`
                }

                dataContainer.innerHTML +=
                    `<article>${properties}</article><br>`; // ��������� �� �������� ��� ������ �����
                console.log(item.id);
            });
        } else {
            console.error('Data not array');
        }

        console.log(books); // ������� ������ � ������� ��� ��������
    })
    .catch(err => {
        console.error(err);
    });