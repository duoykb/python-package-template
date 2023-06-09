﻿string projDir = Ask("proj dir");
List<(string content, string fileName)> templates = new()
{
    ("", "README.md"),
    ($""""
        [metadata]
        name = package-name
        version = 1.0.0
        author = author-name
        author_email = None
        description = A small example package
        long_description = file: README.md
        long_description_content_type = text/markdown
        url = https://example.com
        project_urls =
        Docs = https://docs.example.com
        classifiers =
        { "\t"} Programming Language :: Python :: 3
        { "\t"} License :: OSI Approved :: MIT License
        { "\t"} Operating System :: OS Independent 
        [options]
        package_dir =
        { "\t"} = src
        packages = find:
        python_requires = >=3.6

        [options.packages.find]
        where = src 
        """" , "setup.cfg"),
    (""""   
    [build-system]
    requires = [
    "setuptools>=42",
    "wheel"
    ]
    build-backend = "setuptools.build_meta"
    """", "pyproject.toml"), 
    (""""
        The MIT License (MIT)
        Copyright © 2023 <copyright holders> 
        Permission is hereby granted, free of charge, to any person obtaining a copy of this software
        and associated documentation files (the “Software”), to deal in the Software without 
        restriction, including without limitation the rights to use, copy, modify, merge, publish,
        distribute, sublicense, and/or sell copies of the Software, and to permit  persons to whom the
        Software is furnished to do so, subject to the following conditions: 
        
        The above copyright notice and this permission notice shall be included in all copies or
        substantial portions of the Software. 
        
        THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING 
        BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
        NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
        DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
        FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
        """", "LICENSE")
};

string Ask(string q)
{
    Write($"{q}: ");
    return ReadLine() ?? throw new ArgumentException("Path can't be null");
}

void CreateTemplate()
{
    try
    {
        var srcDir = Path.Combine(projDir, "src");
        var testsDir = Path.Combine(projDir, "tests");
        Directory.CreateDirectory(projDir);
        Directory.CreateDirectory(srcDir);
        Directory.CreateDirectory(testsDir);

        foreach (var (content, fileName) in templates) File.WriteAllText(Path.Combine(projDir, fileName), content);
    }
    catch (IOException)
    {
        WriteLine("Failed");
    }
}

CreateTemplate();