# ClubActivitiesSystem


## 專案技術

- **後端框架**: ASP.NET Core 8 MVC
- **程式語言**: C#
- **資料庫**: Microsoft SQL Server
- **ORM**: Entity Framework Core 8
- **套件管理**: NuGet


## 系統需求

- .NET 8 SDK
- SQL Server 2016 或以上版本
- Visual Studio 2022 / VS Code（或其他支援 .NET 8 的 IDE）


## 安裝與設定

1. **下載專案**

```bash
git clone https://github.com/FLEN2360/ClubActivitiesSystem.git
cd https://github.com/FLEN2360/ClubActivitiesSystem.git
````

2. **設定資料庫連線**

在 `appsettings.json` 中修改 `ConnectionStrings`：

```json
"ConnectionStrings": {
  "DBConnectionString": "Data Source=伺服器位置;Initial Catalog=資料庫名稱;Integrated Security=True;User ID=資料庫使用者名稱;Password=資料庫使用者密碼;Encrypt=False"
}
```

* `Data Source`：SQL Server 伺服器位置（你的電腦名稱）
* `Initial Catalog`：資料庫名稱
* `User ID` / `Password`：資料庫使用者與密碼

3. **還原 NuGet 套件**

```bash
dotnet restore
```

4. **建立資料庫與執行遷移**

使用 Entity Framework Core CLI：

```bash
dotnet tool restore
dotnet ef database update
```


如果有修改 Model 的話：

```bash
dotnet ef migrations add InitialCreate
```


> 注意：如果尚未安裝 `dotnet-ef` 工具，可透過專案中的 `dotnet-tools.json` 直接使用。

## 套件依賴

* `Microsoft.EntityFrameworkCore` 8.0.22
* `Microsoft.EntityFrameworkCore.SqlServer` 8.0.22
* `Microsoft.EntityFrameworkCore.Tools` 8.0.22

---

## 注意事項

* 確保 SQL Server 已啟動且資料庫使用者有權限
* 若資料庫不存在，`dotnet ef database update` 會自動建立
* 可依需求調整 `appsettings.json` 的 LogLevel 與 AllowedHosts

---

## License

此專案採用 MIT License（依需求調整）
