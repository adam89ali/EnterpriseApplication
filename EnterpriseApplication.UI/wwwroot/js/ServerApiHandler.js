function ServerApiHandler() {

    this.GetData = function (url,filter)
    {
        let queryString = "";
        if (typeof (filter) !== 'undefined')
        {
            Object.keys(filter).forEach((key, index) => {
                if (filter[key] !== "") {
                    queryString += key + "=" + filter[key] + "&";
                }
            });
        }       
        if (queryString !== "") url += "?" + queryString;
        return fetch(url,
            {
                method: "GET",
                //body: JSON.stringify(todo),
                headers:
                {
                    'Content-Type': 'application/json;charset=UTF-8',
                    'Accept': 'application/json'
                }
            }
            )
            .then(response => { return response.json(); })
            //.then(json => {
            //    bindDataWithControl(json);
            //  //  console.log(json);
            //})
            .catch(function (error) {
                console.log("Error While calling WebApiUtility.GetData Method :" + error);
            });
    };
}

