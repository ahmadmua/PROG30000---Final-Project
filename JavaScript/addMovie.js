document.getElementById("submit")
    .addEventListener('click', () => {
        //do a post request to the API
        fetch("http://localhost:5117/api/movie/add", {
            method: "POST",
            headers: {
                "content-type": "application/json"
            },
            body: JSON.stringify({
                title: document.getElementById("title").value,
                overview: document.getElementById("overview").value,
                release_date: document.getElementById("release_date").value,
                genre: document.getElementById("genre").value,
                runtime: document.getElementById("runtime").value
            })
        })
            .then(response => response.json())


        //TODO: update the UI to include the new item
    })