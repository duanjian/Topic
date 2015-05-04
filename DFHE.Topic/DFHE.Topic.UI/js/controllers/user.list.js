(function () {
    'use strict';

    angular
        .module('Topic')
        .controller('UserListCtrl', UserListCtrl)
        .directive("createUser", function($modal) {
            return {
                restrict: "A",
                link: function (scope, element, attr) {
                    // 保存
                    scope.createUser = function () {
                        
                    };
                    element.click(function () {
                        //scope.initProductInfo();
                        // 显示数据
                        scope.userInfo = {};
                        scope.modal = $modal({
                            scope: scope,
                            animation: 'am-fade-and-slide-top',  //am-fade-and-slide-top, am-fade-and-scale
                            template: 'templates/user.create.tpl.html',
                            container:'body'
                        });
                    });
                }
            };
        });



    function UserListCtrl($scope) {
        this.scope = $scope;
        this._init();
    }

    UserListCtrl.prototype = {
        _init: function () {
            this._setScope();
        },
        _setScope: function () {
            var _this = this;
            _this._registerMethod();
        },
        _registerMethod: function () {

        }
    }
})();