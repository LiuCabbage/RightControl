[ //节点
  {
      name: '常用文件夹'
    , id: 1
    , alias: 'changyong'
    , children: [
      {
          name: '所有未读'
        , id: 11
        , href: 'http://www.layui.com/'
        , alias: 'weidu'
      }, {
          name: '置顶邮件'
        , id: 12
      }, {
          name: '标签邮件'
        , id: 13
      }
    ]
  }, {
      name: '我的邮箱'
    , id: 2
    , spread: true
    , children: [
      {
          name: 'QQ邮箱'
        , id: 21
        , spread: true
        , children: [
          {
              name: '收件箱'
            , id: 211
            , children: [
              {
                  name: '所有未读'
                , id: 2111
              }, {
                  name: '置顶邮件'
                , id: 2112
              }, {
                  name: '标签邮件'
                , id: 2113
              }
            ]
          }, {
              name: '已发出的邮件'
            , id: 212
          }, {
              name: '垃圾邮件'
            , id: 213
          }
        ]
      }, {
          name: '阿里云邮'
        , id: 22
        , children: [
          {
              name: '收件箱'
            , id: 221
          }, {
              name: '已发出的邮件'
            , id: 222
          }, {
              name: '垃圾邮件'
            , id: 223
          }
        ]
      }
    ]
  }
]