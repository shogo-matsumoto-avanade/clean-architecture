# はじめに

MediatRとFluent validationを使用した独学用のWeb APIプロジェクトサンプル。

順次mainブランチをUpdateしていくが、更新の区切りの良いタイミングでversion/XX-descriptionブランチを切っている。

個人的に重要と思う（忘れがちな）実装を中心にコメントを付与している。

目標としては、CQRSをしつつ、「単体テストの考え方/使い方」で言及されている関数型アーキテクチャを目指し、
テストもMockの使用は最小限に抑えるようにしている。（外部サービス、ドメインログのみMockにする）

MockをDIすることでTestクラスでSetupなどを記述せずとも発生したメソッド実行について検証ができるようにした。<br/>
DBを実装の詳細と考えた際、例えばDBと接続するRepositoryクラスをMockにするのはNGとの解釈から、DBにはテストでも直接アクセスをしている。（初期はInMemoryとしていたが、途中で削除）<br/>
あくまでMockにするのは外部サービスのみとする（抽象化層を挟む場合にはその配下にある依存をMockにする）ことで外部から観測可能な処理について検証ができる。

本リポジトリで導入したもの
- 
- CQRS (MediatR / Fluent Validation)
- EF Core / Migration
- Fluent Assertion

参考資料
-
- [単体テストの考え方/使い方](https://www.amazon.co.jp/%E5%8D%98%E4%BD%93%E3%83%86%E3%82%B9%E3%83%88%E3%81%AE%E8%80%83%E3%81%88%E6%96%B9-%E4%BD%BF%E3%81%84%E6%96%B9-Vladimir-Khorikov/dp/4839981728/ref=sr_1_1?adgrpid=146919524071&dib=eyJ2IjoiMSJ9.DwAMKN29hHMmZWAvUlEn2NudZNv88Uo1SwalHFiQleyg0_GN7TosRS2yyQnrAi_bzgRtXcav-mfjEMpEGvWSqiZ3UiFMSqP1bODjqJZe5GRBof1UP6LHAmpwzUYgkst-E_gkXn171lAQRFUVOrzZAMFJDw-9qTG11ImE2cChz_Q6tu-SM00flHicyVBTxBhaHlDU0BA7wN6zxtTbmNxyagE_hyKIz3XPQ1rL_bnIt5ZrlPO8Y_Mj1v5pOEWD9ZbjONjjiuNydS47vJbH1Hwneg.a3f9Pj-Gzm0DkeuYa3bT1413eBRKZZSGlYCV4rSfEMU&dib_tag=se&hvadid=679002934242&hvdev=c&hvqmt=b&hvtargid=kwd-1930173513296&hydadcr=1792_13657227&jp-ad-ap=0&keywords=%E5%8D%98%E4%BD%93%E3%83%86%E3%82%B9%E3%83%88%E3%81%AE%E8%80%83%E3%81%88%E6%96%B9%2F%E4%BD%BF%E3%81%84%E6%96%B9&qid=1712636255&sr=8-1)
- [Youtuber - MilanJovanovic](https://www.youtube.com/@MilanJovanovicTech)

# おぼえがき

MediatRの機能を用いて、QueryとCommandを呼び出す。

QueryとCommandは DDD\Practice.Ddd\Practice.Ddd.Application\Utilities\Requests 配下にあるInterface群でハンドラを作成しやすいようにしている。

PipelineBehaviorはLogging -> Validation -> UnitOfWork -> Handlerとなるように実装している（DDD\Practice.Ddd\Practice.Ddd.Application\DependencyInjection.cs）。

このUnitOfWorkPipelineBehaviorによって、DbContextをインスタンス化しUnitOfWorkパターンを実現している。
