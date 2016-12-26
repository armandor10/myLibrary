app.controller('HomeCtr', function MainCtrl($scope,$filter, BookService, AuthorService) {

    $scope.bookSelected = {};
    $scope.authorSelected = {};

    $scope.getAll = function () {
        BookService.getAll().then(
            function (resp) {
                $scope.books = resp.data;
            },
            function (err) {
                Console.log(err);
            }
        );
    };

    $scope.getAllAuthors = function () {
        AuthorService.getAll().then(function (resp) {
            $scope.authors = resp.data;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.saveBook = function () {
        $scope.bookSelected.author = $scope.authorSelected.id;
        $scope.bookSelected.image = 'http://www.w3schools.com/bootstrap/cinqueterre.jpg';
        if(!$scope.edit){
            BookService.save($scope.bookSelected).then(
                function (resp) {
                    $scope.getAll();
                    $('#book').modal('toggle');
                    console.log(resp.data);
                },
                function (err) {
                    console.log(err);
                }
            );
        } else {
            BookService.update($scope.bookSelected).then(
                function (resp) {
                    $scope.getAll();
                    $('#book').modal('toggle');
                    console.log(resp.data);
                },
                function (err) {
                    console.log(err);
                }
            );
        }        
    };

    $scope.delete = function (b) {
        BookService.delete(b)
        .then(function (resp) {
            console.log(resp.data);
            $scope.getAll();
        }, function (err) {
            console.log(err);
        });
    };

    $scope.getAuthor = function (id) {
        var author = $filter('filter')($scope.authors, { id: id }, true);
        console.log(author);
        if(author.length > 0)
            return author[0].name;
        return "";
    };

    $scope.editBook = function (ban,book) {
        $scope.edit = ban;
        if (ban) {
            $scope.bookSelected = angular.copy(book);
            //console.log(book);
            $scope.authorSelected = $filter('filter')($scope.authors, { id: $scope.bookSelected.author }, true)[0];
            //console.log($scope.authorSelected);
        } else {
            $scope.bookSelected = {};
            $scope.bookSelected.title = '';
            $scope.bookSelected.description = '';
            $scope.bookSelected.image = '';
        }
    };

});