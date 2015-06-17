(function () {
    'use strict';

    angular
        .module('Topic')
        .controller('TmplCreateCtrl', TmplCreateCtrl);

    function TmplCreateCtrl($scope, topicDict, restSvc, odataSvc) {
        this.scope = $scope;
        this.topicDict = topicDict;
        this.restSvc = restSvc;
        this.odataSvc = odataSvc;
        this._init();
    }

    TmplCreateCtrl.prototype = {
        _init: function () {
            this._setScope();
            this._switch();
            this._on();
        },
        _setScope: function () {
            var _this = this;
            _this.scope.tplTypeDict = _this.topicDict.tplTypeDict;
            _this.scope.colorDict = _this.topicDict.colorDict;
            _this.scope.colorDict4Trans = _this.topicDict.colorDict4Trans;
            _this.scope.selectedType = _this.scope.tplTypeDict[0];
            _this.scope.template = {};
            _this.scope.tabStyle = {
                TabPosition: 'header',
                ShowBottomSubmitButton: true,
                ShowHeader: false,
                TabBackgroundColor: 'positive',
                TabForegroundColor: 'light',
                TabForegroundColorRGB: '#ffffff',
                ContentBackgroundColor: 'stable',
                ContentForegroundColor: 'dark',
                SubmitButtonBackgroundColor: 'positive',
                SubmitButtonForegroundColor: 'light',
                HeaderBackgroundColor: 'positive',
                HeaderForegroundColor: '#ffffff'
            };

            _this.scope.swiperStyle = {
                BackgroundColor: '#444444',
                ForegroundColor: '#f8f8f8',
                ShowPagination: true,
                Direction: 'vertical',
                Autoplay: false,
                AutoplayTimeInterval: 0,
                AutoplayDisableOnInteraction: true,
                Loop:true
            };
            _this.scope.sampleUrl = '';

            _this._registerMethod();

            angular.element(document).ready(function () {
                //Tab页部分-------------------------------------------------------------------------------------

                //顶部导航背景色
                angular.element('#inputHeaderBgColor').on('input', function () {
                    var rgbKey = angular.element(this).val();
                    var colorName = _this.scope.colorDict4Trans[rgbKey];
                    colorName = colorName == undefined ? 'positive' : colorName;
                    _this.scope.tabStyle.HeaderBackgroundColor = colorName;
                });

                //顶部导航前景色
                angular.element('#inputHeaderFColor').on('input', function () {
                    var rgbKey = angular.element(this).val();
                    var colorName = _this.scope.colorDict4Trans[rgbKey];
                    colorName = colorName == undefined ? '#ffffff' : rgbKey;
                    _this.scope.tabStyle.HeaderForegroundColor = colorName;
                });

                //标签背景色
                angular.element('#inputTabBgColor').on('input', function () {
                    var rgbKey = angular.element(this).val();
                    var colorName = _this.scope.colorDict4Trans[rgbKey];
                    colorName = colorName == undefined ? 'positive' : colorName;
                    _this.scope.tabStyle.TabBackgroundColor = colorName;
                });

                //标签前景色
                angular.element('#inputTabFColor').on('input', function () {
                    var rgbKey = angular.element(this).val();
                    _this.scope.tabStyle.TabForegroundColorRGB = rgbKey;
                    var colorName = _this.scope.colorDict4Trans[rgbKey];
                    colorName = colorName == undefined ? 'light' : colorName;
                    _this.scope.tabStyle.TabForegroundColor = colorName;
                });

                //内容背景色
                angular.element('#inputContentBgColor').on('input', function () {
                    var rgbKey = angular.element(this).val();
                    var colorName = _this.scope.colorDict4Trans[rgbKey];
                    colorName = colorName == undefined ? 'stable' : colorName;
                    _this.scope.tabStyle.ContentBackgroundColor = colorName;
                });

                //内容前景色
                angular.element('#inputContentFColor').on('input', function () {
                    var rgbKey = angular.element(this).val();
                    var colorName = _this.scope.colorDict4Trans[rgbKey];
                    colorName = colorName == undefined ? 'dark' : colorName;
                    _this.scope.tabStyle.ContentForegroundColor = colorName;
                });

                //按钮前景色
                angular.element('#inputSubBtnBgColor').on('input', function () {
                    var rgbKey = angular.element(this).val();
                    var colorName = _this.scope.colorDict4Trans[rgbKey];
                    colorName = colorName == undefined ? 'positive' : colorName;
                    _this.scope.tabStyle.SubmitButtonBackgroundColor = colorName;
                });

                //按钮前景色
                angular.element('#inputSubBtnFColor').on('input', function () {
                    var rgbKey = angular.element(this).val();
                    var colorName = _this.scope.colorDict4Trans[rgbKey];
                    colorName = colorName == undefined ? 'light' : colorName;
                    _this.scope.tabStyle.SubmitButtonForegroundColor = colorName;
                });

                //头部标签
                angular.element('#optTabHeader').on('click', function () {
                    _this.scope.tabStyle.TabPosition = angular.element(this).children().val();
                });

                //底部标签
                angular.element('#optTabBottom').on('click', function () {
                    _this.scope.tabStyle.TabPosition = angular.element(this).children().val();
                });


                //Swiper页部分-------------------------------------------------------------------------

                //滑动页背景色
                angular.element('#inputSwiperBgColor').on('input', function () {
                    var rgb = angular.element(this).val();
                    _this.scope.swiperStyle.BackgroundColor = rgb;
                });

                //滑动页前景色
                angular.element('#inputSwiperFColor').on('input', function () {
                    var rgb = angular.element(this).val();
                    _this.scope.swiperStyle.ForegroundColor = rgb;
                });
            });

        },

        _on: function () {

        },

        _switch: function () {
            var _this = this;
            _this.scope.$watch('selectedType.key', _this.scope.switchPreviewSample);
        },

        _registerMethod: function () {
            var _this = this;

            //切换预览示例
            _this.scope.switchPreviewSample = function () {
                var selectedTypeKey = _this.scope.selectedType.key;

                switch (selectedTypeKey) {
                    case 1:
                        _this.scope.switchPreviewIframe('http://localhost:2381/Statics/Samples/Tab/TabTemplateSample.html');
                        break;
                    case 2:
                        _this.scope.switchPreviewIframe('http://localhost:2381/Statics/Samples/Swiper/SwiperTemplateSample.html');
                        break;
                }
            },
            
            //切换预览
            _this.scope.switchPreviewIframe = function (url) {
                var iframe = document.querySelector('#templatePreviewFrame');
                iframe.src = url;
            },

            //预览
            _this.scope.preview = function (e) {

                var btnLoading = angular.element(e.target).button('loading');

                var selectedTypeKey = _this.scope.selectedType.key;

                //_this.scope.template = {};

                switch (selectedTypeKey) {
                    case 1:
                        _this.scope.template = {
                            TemplateTitle: '',
                            TemplateType: 1,
                            TemplateContent: angular.toJson(_this.scope.tabStyle)
                        };
                        break;
                    case 2:
                        _this.scope.template = {
                            TemplateTitle: '',
                            TemplateType: 2,
                            TemplateContent: angular.toJson(_this.scope.swiperStyle)
                        };
                        break;
                }               

                _this.restSvc.post({
                    controller: 'template',
                    action: 'sample',
                }, angular.toJson(_this.scope.template),
                function (res) {
                    var iframe = document.querySelector('#templatePreviewFrame');
                    var previewPah = 'http://localhost:2381/' + res.Data.replace('\\','/');
                    iframe.src = previewPah;
                    btnLoading.button('reset');
                }, function (res) {
                    btnLoading.button('reset');
                });
            },
            _this.scope.save = function (e) {

                var btnSaving = angular.element('#btnSaving').button('loading');

                _this.scope.template = {
                    TemplateTitle: _this.scope.template.TemplateTitle,
                    TemplateType: 1,
                    TemplateContent: angular.toJson(_this.scope.tabStyle)
                };
                _this.restSvc.post({
                    controller: 'template',
                    action: 'sample',
                }, angular.toJson(_this.scope.template),
                function (res) {

                    var iframe = document.querySelector('#templatePreviewFrame');
                    iframe.src = 'http://localhost:2381/Statics/Samples/Tab/TabTemplatePreview.html';

                    _this.scope.template = {
                        TemplateTitle: _this.scope.template.TemplateTitle,
                        TemplateType: _this.scope.selectedType.key,
                        TemplateContent: angular.toJson(_this.scope.tabStyle)
                    };

                    _this.restSvc.post({
                        controller: 'template'
                    }, angular.toJson(_this.scope.template),
                    function (res) {
                        btnSaving.button('reset');
                    }, function (res) {
                        btnSaving.button('reset');
                    });

                    //bootbox.confirm({
                    //    message: "保存前请通过预览查看模版效果，确定保存？",
                    //    callback: function (result) {
                    //        if (result) {

                    //        }
                    //    },
                    //    className: "bootbox-sm"
                    //});

                }, function (res) {
                    btnSaving.button('reset');
                });






            },

            //tab页部分-----------------------------------------------------------------

            //显示底部提交按钮
            _this.scope.optShowBottomSubmit = function () {
                _this.scope.tabStyle.ShowBottomSubmitButton = true;
            },
            //隐藏底部提交按钮
            _this.scope.optHideBottomSubmit = function () {
                _this.scope.tabStyle.ShowBottomSubmitButton = false;
            },
            //显示顶部导航
            _this.scope.optShowHeader = function () {
                _this.scope.tabStyle.ShowHeader = true;
            },
            //隐藏顶部导航
            _this.scope.optHideHeader = function () {
                _this.scope.tabStyle.ShowHeader = false;
            },

            //swiper页部分-----------------------------------------------------------------

            //显示分页
            _this.scope.optShowPagination = function (show) {                
                _this.scope.swiperStyle.ShowPagination = show == 1? true: false;                              
            },

            //滑动方向
            _this.scope.optDirection = function (direction) {
                _this.scope.swiperStyle.Direction = direction == 1? 'horizontal' : 'vertical';
            },

            //自动播放
            _this.scope.optAutoplay = function (auto) {
                _this.scope.swiperStyle.Autoplay = auto == 1 ? true : false;
            },

            //播放可打断
            _this.scope.optAutoplayInteraction = function (disable) {
                _this.scope.swiperStyle.AutoplayDisableOnInteraction = disable == 1 ? true : false;
            },

            //循环
            _this.scope.optLoop = function (loop) {
                _this.scope.swiperStyle.Loop = loop == 1 ? true : false;
            }                       
        }
    }

})();