# UnityMeasure

***Easily measure your code with this library***

[![GitHub last commit](https://img.shields.io/github/last-commit/Prastiwar/UnityMeasure.svg?label=Updated&style=flat-square&longCache=true)](https://github.com/Prastiwar/UnityMeasure/commits/master)
[![license](https://img.shields.io/github/license/Prastiwar/UnityMeasure.svg?style=flat-square&longCache=true)](https://github.com/Prastiwar/UnityMeasure/blob/master/LICENSE)
[![GitHub forks](https://img.shields.io/github/forks/Prastiwar/UnityMeasure.svg?style=social&label=Fork&longCache=true)](https://github.com/Prastiwar/UnityMeasure/fork)
[![GitHub stars](https://img.shields.io/github/stars/Prastiwar/UnityMeasure.svg?style=social&label=★Star&longCache=true)](https://github.com/Prastiwar/UnityMeasure/stargazers)
[![GitHub watchers](https://img.shields.io/github/watchers/Prastiwar/UnityMeasure.svg?style=social&labelWatcher&longCache=true)](https://github.com/Prastiwar/UnityMeasure/watchers)
[![GitHub contributors](https://img.shields.io/github/contributors/Prastiwar/UnityMeasure.svg?style=social&longCache=true)](https://github.com/Prastiwar/UnityMeasure/contributors)

![GitHub repo size in bytes](https://img.shields.io/github/repo-size/Prastiwar/UnityMeasure.svg?style=flat-square&longCache=true)
[![GitHub issues](https://img.shields.io/github/issues/Prastiwar/UnityMeasure.svg?style=flat-square&longCache=true)](https://github.com/Prastiwar/UnityMeasure/issues)
[![GitHub closed issues](https://img.shields.io/github/issues-closed/Prastiwar/UnityMeasure.svg?style=flat-square&longCache=true)](https://github.com/Prastiwar/UnityMeasure/issues)
[![GitHub pull requests](https://img.shields.io/github/issues-pr/Prastiwar/UnityMeasure.svg?style=flat-square&longCache=true)](https://github.com/Prastiwar/UnityMeasure/pulls)
[![GitHub closed pull requests](https://img.shields.io/github/issues-pr-closed/Prastiwar/UnityMeasure.svg?style=flat-square&longCache=true)](https://github.com/Prastiwar/UnityMeasure/pulls)

[![Made with Unity](https://img.shields.io/badge/Made%20with-Unity-000000.svg?longCache=true&style=for-the-badge&colorA=666677&colorB=222222)](https://unity3d.com/)

## Before start

- [x] Make sure you have at least **Unity 2017.3** (previous versions weren't tested).  


## Getting Started

See our wiki for [documentation](https://github.com/Prastiwar/UnityMeasure/wiki).  


## Using

```cs
using System;
using TP.Measurement; // import this namespace to use the library

public class TestScript : TPTestScript
{
    // Return all Action you want to automatically measure
    protected override Action[] GetActionsToMeasure()
    {
        return new Action[] {
            Void, // Void is empty method from TPTestScript
            // ()=> { MyMethod(); },
            ()=> { bool isUntagged = gameObject.tag == "Untagged"; },
            ()=> { bool isUntagged = gameObject.CompareTag("Untagged"); },
            ()=> { bool isUntagged = gameObject.tag.Equals("Untagged"); }
        };
    }

    // Calls after Unity's Start method
    protected override void OnStarted()
    {
        MeasureAverageRepeat(); // automatically measures all action from GetActionsToMeasure()
        TPMeasure.Measure("My custom measure", () => { /* code */ }).ShowLog();
    }

    // Code in this section will be showed in Unity's profiler
    protected override void UpdateProfile()
    {
        // code
    }

    private void MyMethod()
    {
        // code
    }
}
``` 
#### Settings:
![Settings](https://i.imgur.com/d71CDZY.png)

#### Results:
![Results](https://i.imgur.com/DgNQwHS.png)


## Contributing

You can freely contribute with us by reporting issues and making pull requests!  
Please read [CONTRIBUTING.md](https://github.com/Prastiwar/UnityMeasure/blob/master/.github/CONTRIBUTING.md) for details on contributing.

## Authors

* ![Avatar](https://avatars3.githubusercontent.com/u/33370172?s=40&v=4)  [**Tomasz Piowczyk**](https://github.com/Prastiwar) - *The Creator*  
See also the list of [contributors](https://github.com/Prastiwar/UnityMeasure/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/Prastiwar/UnityMeasure/blob/master/LICENSE) file for details.
