angular.module('gbApp', [])
    .controller('categoryController', ['$scope', '$http',
        function ($scope, $http) {
            var defaultCategoryId = 1;

            var categoryModel = this;
            categoryModel.categories = [];

            categoryModel.isAddCategory = false;
            categoryModel.selectedCategory;


            $scope.init = function () {
                $scope.loadCategories();
            };

            $scope.loadCategories = function () {
                let url = "/api/post/GetAllCategories";

                $http.get(url)
                    .then(function (response) {
                        $scope.categories = response.data;
                        $scope.selectedCategory = $scope.categories.find(o => o.id === defaultCategoryId);
                    }, function (response) {
                        toastr["error"]("Failed to load categories");
                    });
            };

            $scope.addCategory = function () {
                $scope.isAddCategory = true;
            };

            $scope.cancelAddCategory = function () {
                $scope.isAddCategory = false;
            };

        }
    ]);





