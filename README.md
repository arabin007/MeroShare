# MeroShare Share Application Automation

This project is built on **.NET Core 9 Runtime** and requires some initial setup before running.  
Follow the steps below to get started.

---

## 🚀 Prerequisites

- [.NET Core 9 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet) installed on your system  

---

## ⚙️ Setup Instructions

1. **Clone the project**  
   ```bash
   git clone https://github.com/arabin007/MeroShare.git
   ```

2. **Create a new `appsettings.json` file**  
   - Copy the content from the provided `appsettings.Development.json` file.  
   - Create a new file named `appsettings.json` in same location and paste the content into a new file.

3. **Update the configuration in `appsettings.json`**  
   - Replace placeholder names (`Rabin` and `Sam`) with your own details.  
   - Add **MeroShare-specific details** in the fields marked with `xxxxx`.  
   - You may add as many users as needed by following the existing structure.

4. **Clean and build the solution**  
   ```bash
   dotnet clean
   dotnet build
   ```

5. **Run the project**  
   ```bash
   dotnet run
   ```

6. **Default URL**  
   By default, the project will run at:  
   http://localhost:5000/meroshare

7. **Passing User Information**  
   To pass the user information, add the `User` query parameter in the URL.  
   Example:  
   ```
   http://localhost:5000/meroshare?User=Rabin
   ```
   Make sure the `User` name matches the one specified in your `appsettings.json`.

---

## 📌 Notes

- Most of the activities are automated.  
- However, the end user still needs to **select the share they want to apply for** – because not everything in life can be automated. 😉  
- Ensure your `appsettings.json` is excluded from version control if it contains sensitive credentials.  

Cheers !!! 🎉
