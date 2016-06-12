## Karma.Service 사용법 
### 1. 데이터베이스 생성방법 

Entity Framework Code First를 사용해서 Database에 Access합니다. 현재 두개의 엔티티가 정의되어 있습니다. Quests / Badges / Users 

Auth구현이 안되어서 User 정보가 없어 먼저 구현을 해야겠습니다.  

VS 2015 > View > Other Windwos > Package Manager Conole 창을 열고 Default Project를 "Karma.Services" 로 놓고 아래 명령어를 실행합니다. 

    update-database -v

이렇게 하면 Web.config 에 ConnectionString 에 정의된 Database에 테이블을 만들고 기본 데이터(Seed)를 널습니다. 확인은 VS 2015에서 SQL Server Object Explorer 또는 SQL Server Management Studio에서 확인 합니다. 

### 2. API 테스트 

현재 Quest API가 구현되어 있는데 User가 없어서 테스트에 한계가 있지만 테스트 방법은 Karma.Services를 VS에서 실행하고 

    https://localhost:44310/swagger

로 접속 합니다.  Swagger UI를 통해서 테스트 가능합니다. 
 