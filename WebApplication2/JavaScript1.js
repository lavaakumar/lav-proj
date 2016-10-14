var TestCtrl = function ($scope, $http) {
    $scope.firstCall = function () {
        debugger;
        $http({
            url: "NewRoute/getDataForAngularGrid",
            dataType: 'json',
            method: 'GET',
            data: '',
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            debugger;
            $scope.CustomerList = response;
        })
           .error(function (error) {
               alert(error);
           });
    }

    $scope.SendData = function (Data) {
        var GetAll = new Object();
        GetAll.FirstName = Data.firstName;
        GetAll.SecondName = Data.lastName;
        GetAll.SecondGet = new Object();
        GetAll.SecondGet.Mobile = Data.mobile;
        GetAll.SecondGet.EmailId = Data.email;
        $scope.IsToBeShown = true;
        $http({
            url: "NewRoute/firstCall",
            dataType: 'json',
            method: 'POST',
            data: GetAll,
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            $scope.value = response;
        })
           .error(function (error) {
               alert(error);
           });
    }
};