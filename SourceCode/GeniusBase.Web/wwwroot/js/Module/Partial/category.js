angular.module('gbApp', [])
    .controller('categoryController', function ($scope) {
        var categoryModel = this;
        easyNav.GroupLinks = LinkleyData;
        easyNav.FileOrFolderMessage = 'Recomended to use IE browser for viewing folder or file links as it will open the orginal folder or file';

        window.angular.element(function () {
            $('.grid').masonry({
                horizontalOrder: true
            });

            $('[data-toggle="popover"]').popover({
                placement: 'right',
                trigger: "hover",
                html: true
            });
        });

        $scope.urlIsFile = function (filePath) {
            return filePath.indexOf("file://") === 0;
        }

        $scope.isIE = function () {
            return window.document.documentMode !== undefined;
        }

        $scope.fileTypeIcon = function (filePath) {
            var fileType = filePath.split('.').pop();
            var isFolder = fileType.indexOf("file://") === 0;

            if (isFolder) {
                return "fa-folder";
            }

            if (["docx", "doc"].indexOf(fileType) >= 0) {
                return "fa-file-word";
            }

            if (["xlsx", "xls"].indexOf(fileType) >= 0) {
                return "fa-file-excel";
            }

            if (["pdf"].indexOf(fileType) >= 0) {
                return "fa-file-pdf";
            }

            if (["pdf"].indexOf(fileType) >= 0) {
                return "fa-file-pdf";
            }

            return "fa-file";
        }


    });




