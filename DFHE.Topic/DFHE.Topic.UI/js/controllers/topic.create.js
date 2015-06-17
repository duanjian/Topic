(function () {
    'use sstrict';

    angular
        .module('Topic')
        .controller('TopicCreateCtrl', TopicCreateCtrl);


    function TopicCreateCtrl($scope, netSettings, restSvc, odataSvc, topicDict) {
        this.scope = $scope;
        this.netSettings = netSettings;
        this.restSvc = restSvc;
        this.odataSvc = odataSvc;
        this.topicDict = topicDict;
        this._init();
    }

    TopicCreateCtrl.prototype = {
        _init: function () {
            this._setScope();
            this._watch();
            this._on();
        },
        _setScope: function () {
            var _this = this;
            _this.scope.requireInfo = _this.topicDict.reqDict;
            _this.scope.tplTypeDict = _this.topicDict.tplTypeDict;
            _this.scope.stepDict = {};
            _this.scope.stepDict = {
                isStep1: true,
                isStep2: true,
                isStep3: true,
                isStep4: true
            };

            _this.scope.tmplImageList = [];

            _this.scope.page = {
                PageTitle: 'title',
                PageContent: 'content'
            };
            _this.scope.pages = [];

            _this.scope.tab = {
                PageTitle: 'title',
                PageContent: 'content'
            };

            _this.scope.tabs = [];
            _this.scope.tabs.activeTab = 0;
            _this.scope.Topic = {
                Title: 'title',
                Type: 1,
                TemplateId: 1,
                SubmitType: 1,
                RedirectURI: '',
                RequireInfo: [],
                PageCount: 1,
                Pages: _this.scope.tabs
            };
            _this.scope.Topic.TplType = 1;
            _this._registerMethod();
            _this.scope.getTemplates();

            

        },
        _watch: function () {
            var _this = this;
            _this.scope.$watch('Topic.PageCount', _this.scope.generatePage);
        },
        _on: function () {
            var _this = this;
            _this.scope.$on('ngRepeatFinished', function (ngRepeatFinishedEvent) {
                _this.scope.tabs.activeTab = 0;

                angular.element(document).ready(function () {
                    angular.element('#signin-demo img').eq(0).addClass('selectedTmplImg');

                    angular.element('#signin-demo img').on('click', function () {
                        angular.element('#signin-demo img').removeClass('selectedTmplImg');
                        angular.element(this).addClass('selectedTmplImg');
                        _this.scope.Topic.TemplateId = angular.element(this).data('tmplid');
                    });
                });
            });
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
            },
            _this.scope.getTemplates = function () {
                // /odata/Template?$select=ID,TemplateTitle,ImageURI                
                //_this.http.get('http://localhost:2381/odata/Template?$select=ID,TemplateTitle,ImageURI').
                //      success(function (data, status, headers, config) {
                //          // this callback will be called asynchronously
                //          // when the response is available
                //          alert(data);
                //      }).
                //      error(function (data, status, headers, config) {
                //          // called asynchronously if an error occurs
                //          // or server returns response with an error status.
                //      });

                _this.odataSvc.query({
                    entityset: 'Template',
                    queries: '$select=ID,TemplateTitle,ImageURI'
                }).success(function (res) {

                    angular.forEach(res, function (k, v) {

                        var tmplImg = {
                            TemplateId: k.ID,
                            TemplateTitle: k.TemplateTitle,
                            ImageURI: _this.netSettings.baseURL + k.ImageURI
                        };

                        _this.scope.tmplImageList.push(tmplImg);

                    });

                    _this.scope.Topic.TemplateId = _this.scope.tmplImageList[0].TemplateId;

                }).error(function (res) {

                });



            },

            //_this.scope.generatePage = function () {
            //    _this.scope.Pages = [];
            //    for (var i = 0; i < _this.scope.Topic.PageCount; i++) {
            //        _this.scope.Page = {
            //            Title: 'title',
            //            Content: 'content'
            //        };
            //        _this.scope.Pages.push(_this.scope.Page);
            //    }
            //},
            _this.scope.generatePage = function () {
                //原标签对象数组长度
                var originalLength = _this.scope.tabs.length;
                //减少标签时
                if (originalLength > _this.scope.Topic.PageCount) {
                    _this.scope.tabs.splice(_this.scope.Topic.PageCount);
                    //增加标签时
                } else {
                    for (var i = originalLength; i < _this.scope.Topic.PageCount; i++) {
                        _this.scope.tab = {
                            PageTitle: 'untitled',
                            PageContent: ''
                        };
                        _this.scope.tabs.push(_this.scope.tab);
                    }
                }
            },
            _this.scope.selectImg = function (target) {
                //angular.element(target).css('outline: -webkit-focus-ring-color auto 5px; opacity: .5;');
                //target.target.css('outline: -webkit-focus-ring-color auto 5px; opacity: .5;');
                //var tmp = target.target;
                //angular.element('#signin-demo img').css('', '');
                //angular.element(target.target).css('outline', ' -webkit-focus-ring-color  auto 5px');

                //angular.element(target.target).css('outline', ' -webkit-focus-ring-color  auto 5px');
                //console.log(tmp);
            },
             _this.scope.preview = function (e) {

                 var btnLoading = angular.element(e.target).button('loading');

                 console.log(_this.scope.Topic);

                 _this.restSvc.post({
                     controller: 'topic',
                     action: 'sample',
                 }, angular.toJson(_this.scope.Topic),
                 function (res) {

                     var iframe = document.querySelector('#tabTopicPrevFrame');
                     iframe.src = 'http://localhost:2381/Statics/Samples/Tab/TabPreview.html';

                     btnLoading.button('reset');
                 }, function (res) {
                     btnLoading.button('reset');
                 });

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