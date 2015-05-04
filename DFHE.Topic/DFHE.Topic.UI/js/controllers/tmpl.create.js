(function() {
    'use strict';

    angular
        .module('Topic')
        .controller('TmplCreateCtrl', TmplCreateCtrl);

    function TmplCreateCtrl($scope, topicDict) {
        this.scope = $scope;
        this.topicDict = topicDict;
        this._init();
    }

    TmplCreateCtrl.prototype = {
        _init: function() {
            this._setScope();
        },
        _setScope: function() {
            var _this = this;
            _this.scope.tplTypeDict = _this.topicDict.tplTypeDict;
            _this.scope.selectedType = _this.scope.tplTypeDict[0];
            _this._registerMethod();
        },
        _registerMethod:function() {
            
        }
    }

})();