<a name="readme-top"></a>{#readme-top}

<div align="center">
  <h3>Blazor Finance</h3>

  <p>A portfolio management tool focused on retirement planning</p>
</div>
  
  <!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
        <ul>
            <li><a href="#built-with">Built With</a></li>
        </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#institutions">Institutions</a></li>
        <li><a href="#accounts">Accounts</a></li>
        <li><a href="#assets">Assets</a></li>
        <li><a href="#income">Income</a></li>
        <li><a href="#expenses">Expenses</a></li>
        <li><a href="#templates">Templates</a></li>
      </ul>
    </li>
    <li><a href="#projections">Projections</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#disclaimer">Disclaimer</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->
## About The Project
The Blazor Finance project was created as a learning exercise, with a focus on ASP.NET Core Blazor.  It will run in standalone mode, but an internet connection is required to get the latest asset market values.

The application is explicitly intended for use on a local workstation, without a direct connection to external institutions for importing portfolio assets.  This was a deliberate design decision to limit security vulnerabilities.  As such, application configuration is performed manually, with a portfolio import tool (from file) designated as a roadmap item.

<p>(<a href="#readme-top">back to top</a>)</p>


### Built With

* <a href="https://learn.microsoft.com/en-us/aspnet/core/blazor/progressive-web-app?view=aspnetcore-8.0&tabs=visual-studio">Blazor Progressive Web Application (PWA)</a>
* <a href="https://blazorise.com/">Blazorise</a>
* <a href="https://getbootstrap.com/">Bootstrap</a>
* <a href="https://www.litedb.org/">LiteDB</a>

<p>(<a href="#readme-top">back to top</a>)</p>


<!-- GETTING STARTED -->
## Getting Started
The relationship of financial entities is important for creating an accurate projection of retirement.  They have a hierarchical releationship and should generally be created in the following order:

### Institutions
Insitutions are the base entity used to create a portfolio.  It is possible to receive Income directly from an Institution, but for the most part they are intended to be a parent for Accounts.

* FK relationship to Income

### Accounts
An Account maintains a balance and serves as a repository for Income.  It can also appreciate on an annual basis (such as interest from a savings acount).

Typical Account types are Savings, Checking, IRA, 401K, etc.

* FK relationship to (parent) Institution

### Assets
Assets are grouped based on liquidity.  Liquid assets (stocks, bonds, etc.) are held in an account, while illiquid assets are usually standalone (collectibles, real estate, etc.).  Both can appreciate on an annual basis.

* KF relationship to (parent) Account

### Income
Income received directly from an Institution (wages, pension, socal security, etc.).  Note that for the purposes of our projections, income received fom asset (interest, dividends, etc.) will be lumped in with annual growth and "re-invested" (increasing the value of the Asset).

* FK relationship to Institution (that Income was received from)
* FK relationship to Account (that Income will be deposited to)
* FK relationship to Asset (that Income will be invested in)

NOTE: If an Account and Asset are both associated with the same Income record, a 50% allocation will be assumed.  For different allocation percentages, it is prefereable to create separate records with each Income Asset or Account receiving a specific dollar ammount.

### Expenses
Expenses can be "paid for" by an Account "withdrawal" or "selling" a portion of an Asset.

TIP: Use "Debt" for big ticket purchases, such as Homes, Cars, etc.  This will ensure an accurate calculation of net worth (total assets - liabilities)

* FK relationship to Account (that Expenses are "withdrawn" from)
* FK relationship to Asset (that are sold to "pay" for Expenses)

NOTE: If an Account and Asset are both associated with the same Expense record, a 50% allocation will be assumed.  For different allocation percentages, it is prefereable to create separate records with each Expense Asset or Account receiving a specific dollar ammount.

### Templates
Templates are used to identify the ordinal position of columns in brokerage portfolio import files (.csv format).  

Each brokerage seems to use their own export format.  Templates are used to identify the Ticker, Description, Shares, and Price columns in the export file.

TIP: All positions selected on import will adopt the Asset Type defined in the portfolio.  Multiple templates can be defined for each brokerage file (one for each Asset Type).

For example:

Type                Name                    Ticker Label        Description Label       Shares Label        Price Label
ExchangeTradedFund  Charles Schwab ETF      Symbol              Description             Qty (Quantity)      Price
Stock               Charles Schwab Stock    Symbol              Description             Qty (Quantity)      Price

<p>(<a href="#readme-top">back to top</a>)</p>

## Projections
Calculation Used

Length of Projection (years) = Expiration Age - Current Age

Daily Interest = Balance * (( AnnualGrowth/100 ) / 365) (or use the actual days in year)

Daily Inflation = Balance * (( AnnualInflation/100 ) / 365) (or use the actual days in year)

For Each Year In Projection

    For Each Day In Year

        Get Expenses Where Day Falls Between the Expense Start Date and End Date
        Subtract Expenses From Account Balance and/or Asset Market Value
        Add Daily Inflation to Expenses

        Get Income Where Day Falls Between the Income Start Date and End Date
        Add Income to Account Balance and/or Asset Market Value

        Add Daily Interest to Account Balance and Asset Market Value
        Add Daily Inflation to Expense Amount


<p>(<a href="#readme-top">back to top</a>)</p>

## Roadmap

* Feature Refinement: Improve validation and error handling of Portfolio Import Tool (from csv file)
* Feature Refinement: Improve accuracy and execution performance of Projections and Summary -> Net Worth Projections
* Project Framework: Add automated test framework/project
* New Feature: Add Quicken file option to Portfolio Import Tool
* New Feature: Selectable/Saveable Database File

<p>(<a href="#readme-top">back to top</a>)</p>

## License
License?

<p>(<a href="#readme-top">back to top</a>)</p>

## Disclaimer

<p>(<a href="#readme-top">back to top</a>)</p>

## Contact

<p>(<a href="top">back to top</a>)</p>