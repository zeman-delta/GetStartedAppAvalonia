1. instalace .NET SDK
2. instalace IDE (Rider/Visual Studio)
3. instalace Avalonia SDK
    - příkaz `dotnet new install Avalonia.Templates`
4. vytvoření nového projektu
   1. rider
      - New Solution
      - Custom template -> Avalonia MVVM App
   2. visual studio
      1. In Visual Studio, click File → New → Project/Solution.
      2. In the search box, input “Avalonia”.
      3. Select Avalonia .NET MVVM App from the search results. If Visual Studio offers multiple options, select the one for C#. Then, click Next.
      4. Name your project “GetStartedApp”.
      5. Change the target directory if desired. Then, click Next.
      6. Select your preferred version of .NET as the framework.
      7. If given the option to choose target platforms, select Desktop.
      8. Click Create.
5. spuštění projektu
   1. rider
      - Run
   2. visual studio
      - Run
6. instalace XAML preview
   1. rider
       - Plugins
       - AvaloniaRider
   2. visual studio
      - Extensions → Manage Extensions
      - Avalonia
7. Test preview
   - MainWindow.axaml
   - Text="{Binding Greeting}" → "Nice preview!"
