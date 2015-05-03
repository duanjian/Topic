(function () {
    'use sstrict';

    angular
        .module('Topic')
        .controller('TopicCreateCtrl', TopicCreateCtrl);

    function TopicCreateCtrl($scope,topicDict) {
        this.scope = $scope;
        this.topicDict = topicDict;
        this._init();
    }

    TopicCreateCtrl.prototype = {
        _init: function () {
            this._setScope();
            this._watch();
        },
        _setScope: function () {
            var _this = this;
            _this.scope.requireInfo = _this.topicDict.reqDict;
            _this.scope.stepDict = {};
            _this.scope.stepDict = {
                isStep1: true,
                isStep2: true,
                isStep3: true,
                isStep4: true
            };
            _this.scope.Topic = {
                Title: 'title',
                TplType: 1,
                SubmitType: 1,
                RedirectUrl: '',
                RequireInfo: [],
                PageCount: 1,
                Page:_this.scope.Page
            };
            _this.scope.Page = {
                Title: 'title',
                Content: 'content'
            };
            _this.scope.Pages = [];
            _this._registerMethod();
        },
        _watch: function () {
            var _this = this;
            _this.scope.$watch('Topic.PageCount', _this.scope.generatePage);
        },
        _registerMethod: function () {
            var _this = this;

            _this.scope.goStep = function (step) {
                //Wizard Nav
                _this.scope.stepDict = {
                    isStep1: true,
                    isStep2: true,
                    isStep3: true,
                    isStep4: true
                };
                for (var i = 1; i <= step; i++) {
                    var isStep = 'isStep' + i;
                    _this.scope.stepDict[isStep] = false;
                }
                //Wizard Div
                for (var i = 1; i <= 4; i++) {
                    angular.element('#wizard-example-step' + i).css('display', 'none');
                }
                angular.element('#wizard-example-step' + step).css('display', 'block');
                //var isStep = 'isStep' + step;
                //_this.scope.stepDict[]

            },
            _this.scope.generatePage = function () {
                _this.scope.Pages = [];
                for (var i = 0; i < _this.scope.Topic.PageCount; i++) {
                    _this.scope.Page = {
                        Title: 'title',
                        Content: 'content'
                    };
                    _this.scope.Pages.push(_this.scope.Page);
                }
            }
            //_this.scope.test = function () {
            //    //var html = document.frames("prevFrame").document.getElementsByTagName('html').value();
            //    var html = angular.element(window.frames['prevFrame']);
            //    var html2 = window.frames['prevFrame'].contentWindow.document;
            //    html2 = html2.getElementsByTagName('body')[0];
            //    $(html2).css("-webkit-transform", "scale(0.3)");                
            //}         
            //_this.scope.load = function () {
                //$.getScript('/assets/javascripts/jquery-1.11.2.js', function () {
                //    alert(1);
                //    //angular.element('<script src="/assets/javascripts/jquery-1.11.2.js"></script>').appendTo(window.document);
                //});

                //var domElem = '<script src="/assets/javascripts/jquery-1.11.2.js" async defer></script>';
                //$('#create').append($compile(domElem)(scope));
            //}
        }
    }
})();