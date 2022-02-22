using Xunit;
using SiesaContact;
using SiesaDirectory;
using SiesaMenu;
using System;
using Test;

namespace SiesaDirectory.Tests;

public class UnitTest1
{
    enum Result
    {
        failure = 0,
        success = 1,
    }
    const bool success = true;
    const bool failure = false;

    [Theory]
    [InlineData("pepita","123","123")]
    [InlineData("ortensio","123","123")]
    public void AddContactSUCCESS(string name, string home, string cellphone)
    {
        bool result = new TestDirectory().TestAddContact(name, home, cellphone);
        Assert.Equal<bool>(result, success);
    }

    [Theory]
    [InlineData("pepita")]
    public void FindContactSUCCESS(string name){
        
        int result = new TestDirectory().TestFindContact(name);
        Assert.Equal((int)Result.success, result);
    }

    [Theory]
    [InlineData("pepito")]
    public void FindContactFAIL(string name){
        
        int result = new TestDirectory().TestFindContact(name);
        Assert.Equal((int)Result.failure, result);
    }

    [Fact]
    public void ListContactSUCCESS(){
        
        bool result = new TestDirectory().TestListContact();
        Assert.Equal<bool>(result, success);
    }

    [Fact]
    public void ListContactFAIL(){
        
        bool result = new TestDirectory().TestListContactVoid();
        Assert.Equal<bool>(result, failure);
    }

    [Theory]
    [InlineData("pepita")]
    public void DeleteContactSUCCESS(string name){
        
        bool result = new TestDirectory().TestDelete(name);
        Assert.Equal<bool>(result, success);
    }

    [Theory]
    [InlineData("pepito")]
    public void DeleteContactFAIL(string name){
        
        bool result = new TestDirectory().TestDelete(name);
        Assert.Equal<bool>(result, failure);
    }

    [Theory]
    [InlineData(2)]
    public void DirectoryFull(int size){

        bool result = new TestDirectory().TestDirectoryFull(size);
        Assert.Equal<bool>(result, success);
    }

    [Fact]
    public void SpaceDirectory(){
        
        bool result = new TestDirectory().TestSpaceDirectory();
        Assert.Equal<bool>(result, success);
    }
}