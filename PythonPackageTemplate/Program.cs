string projDir = Ask("proj dir");
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
    """", "pyproject.toml")
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

        foreach (var (content, f) in templates) File.WriteAllText(Path.Combine(projDir, f), content);
    }
    catch (IOException)
    {
        WriteLine("Failed");
    }
}

CreateTemplate();