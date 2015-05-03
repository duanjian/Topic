(function () {
    'use strict';

    angular
        .module('Topic.net', ['ngResource', 'ngCookies'])
        .factory('restSvc', function ($resource) {
            return $resource("api/:controller/:action/:id", { controller: "@controller", action: "@action", id: "@id" },
        {
            get: {
                method: "get",
                headers: { "Authorization": 'Basic' + ' ' + $cookieStore.get("Authorization") }
            },
            post: {
                method: "post",
                headers: { "Authorization": 'Basic' + ' ' + $cookieStore.get("Authorization") }
            },
            delete: {
                method: "delete",
                headers: { "Authorization": 'Basic' + ' ' + $cookieStore.get("Authorization") }
            },
            put: {
                method: "put",
                headers: { "Authorization": 'Basic' + ' ' + $cookieStore.get("Authorization") }
            }
        });
        })
        .factory("loginInfo", function ($window, $cookies, $cookieStore) {
            var loginInfo = $cookies["current_employee"] || $cookieStore.get("current_employee");
            //var loginInfo = $cookieStore.get("current_employee");

            //$scope.$watch(function () { return $cookies["current_employee"]; }, function () {
            //    $scope.name = "cookie:" + $cookies['test'];
            //    alert($cookies["current_employee"]);
            //});

            if (!loginInfo) {
                // 没有登录信息，跳转到登录界面
                $window.location.href = "/login.html";
                return null;
            }
            var result = window.Base64.decoder(loginInfo);
            return JSON.parse(result);
        })
})();