(function () {
    'use strict';

    var baseURL = 'http://localhost:2381/'

    angular
        .module('Topic.net', ['ngResource', 'ngCookies'])
        .factory('restSvc', function ($resource, $cookies) {
            return $resource(baseURL + 'api/:controller/:action/:id', { controller: '@controller', action: '@action', id: '@id' },
        {
            get: {
                method: 'get',
                headers: { 'Authorization': 'Basic' + ' ' + $cookies['Authorization'] }
            },
            post: {
                method: 'post',
                headers: { 'Authorization': 'Basic' + ' ' + $cookies['Authorization'] }
            },
            delete: {
                method: 'delete',
                headers: { 'Authorization': 'Basic' + ' ' + $cookies['Authorization'] }
            },
            put: {
                method: 'put',
                headers: { 'Authorization': 'Basic' + ' ' + $cookies['Authorization'] }
            }
        });
        })
        .factory('odataSvc', function ($http, $resource, $cookies) {
            return {
                query: function (args) {
                    var entityset = args.entityset;
                    var queries = args.queries;
                    return $http.get(baseURL + 'odata/' + entityset + '?' + queries);
                }
            }
        })
        .factory('loginInfo', function ($window, $cookies) {
            var loginInfo = $cookies['current_employee'];
            //var loginInfo = $cookieStore.get('current_employee');

            //$scope.$watch(function () { return $cookies['current_employee']; }, function () {
            //    $scope.name = 'cookie:' + $cookies['test'];
            //    alert($cookies['current_employee']);
            //});

            if (!loginInfo) {
                // 没有登录信息，跳转到登录界面
                $window.location.href = '/login.html';
                return null;
            }
            var result = window.Base64.decoder(loginInfo);
            return JSON.parse(result);
        })
    .factory('netSettings', function () {
        return {
            baseURL: baseURL
        }
    });
})();