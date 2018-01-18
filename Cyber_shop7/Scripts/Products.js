var uri = 'http://localhost:49800/api/Mobiles/';
var urib = 'http://localhost:49800/api/Books/';
var urif = 'http://localhost:49800/api/Foods/';
var uric = 'http://localhost:49800/api/Clothing/';



var app = angular.module('Products', []);

app.controller('MobilesController', function ($scope, $http) {
    $http.get(uri).
        then(function (response) {
            $scope.mobiles = response.data;
        });
});
app.controller('BooksController', function ($scope, $http) {
    $http.get(urib).
        then(function (response) {
            $scope.books = response.data;
        });
});
app.controller('CartsController', function ($scope, $http) {
    $http.get(uri).
        then(function (response) {
            $scope.carts = response.data;
        });
});
app.controller('ClothingsController', function ($scope, $http) {
    $http.get(uric).
        then(function (response) {
            $scope.clothings = response.data;
        });
});
app.controller('FoodsController', function ($scope, $http) {
    $http.get(urif).
        then(function (response) {
            $scope.foods = response.data;
        });
});
