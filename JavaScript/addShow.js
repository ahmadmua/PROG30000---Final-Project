document.getElementById("submit")
    .addEventListener('click', () => {
        //do a post request to the API
        fetch("http://localhost:5117/api/shows/add", {
            method: "POST",
            headers: {
                "content-type": "application/json"
            },
            body: JSON.stringify({
                title: document.getElementById("title").value,
                overview: document.getElementById("overview").value,
                release_date: document.getElementById("release_date").value,
                genre: document.getElementById("genre").value,
                Episodes: document.getElementById("episodes").value,
                Seasons: document.getElementById("seasons").value,
            })
        })
            // .then(response => response.json())
            .then(res => {

                if (res.ok) {

                    alert("Movie was added!")

                } else {

                    res.text().then(text => alert(text))
                }
            })


        //TODO: update the UI to include the new item
    })