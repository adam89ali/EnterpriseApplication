function DataLoader() {

    this.LoadData = function (Url,filter)
    {
        return fetch(Url,
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

