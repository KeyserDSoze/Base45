# Base45
Base45 Encrypting and Decrypting

# Usage
using System.Text;

string value = "Hello";

string base45Value = value.ToBase45();

string returnToValue = base45Value.FromBase45();
