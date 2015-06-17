(function () {
    'use strict';

    angular
        .module('Topic')
        .controller('MainCtrl', MainCtrl);

    function MainCtrl($scope) {
        this.scope = $scope;
        this._init();
    }

    MainCtrl.prototype = {
        _init: function () {
            this._setScope();
        },
        _setScope: function () {
            var _this = this;
            _this._registerMethod();

            angular.element(document).ready(function () {
                var navList = angular.element('.navigation li');
                navList.each(function (k, v) {                    
                    angular.element(v).on('click', function () {
                        angular.element('#aUserList').removeClass('active');
                        angular.element(this).addClass('active');
                        var tmplis = angular.element(this).siblings();
                        tmplis.each(function (k, v) {
                            angular.element(this).removeClass('active');
                        });
                    });
                });

                angular.element('#aUserList').on('click', function () {
                    angular.element(this).addClass('active');
                    navList.each(function (k, v) {
                        angular.element(this).removeClass('active');
                    });
                });

                angular.element('#main-menu-toggle').on('click', function () {
                    angular.element('body').toggleClass('mmc');                    angular.element('body').toggleClass('mme');
                });

                
            });

        },
        _registerMethod: function () {
            var _this = this;
        }
    }
})();