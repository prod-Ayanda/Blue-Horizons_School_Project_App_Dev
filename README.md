## Ayanda's Changes To The System 
1. Class & File Renaming
Dashboard → frmHome → Home (final name), matching project's naming convention
Form1/frmHome (original Welcome screen) → frmWelcome → Welcome (final name)
Updated all cross-references: Login.cs now opens new Home(), Home.cs logout opens new Welcome(), Program.cs starts on new Welcome()

2. Bug Fixes (unrelated to renaming, found while reading the code)
Login.cs & Register.cs: replaced hardcoded absolute file path (C:\Users\user\OneDrive...) with a portable path (Path.Combine(Application.StartupPath, "ProjectApdp.txt")) so the app works on any machine, not just the one it was written on
Register.cs: fixed this.Show() → this.Hide() after successful registration, which was leaving the Register window open on top of the new Login window
