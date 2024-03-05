using Linode.Api.Objets.StackScript;

namespace Linode.Api.Tests
{
    public class StackScriptClientTest
    {
        private readonly LinodeClient _linodeClient = new LinodeClient(File.ReadAllText("D:\\Linode.Api.txt"));

        [Fact]
        public async Task GetAllTest()
        {
            // Arrange

            // Act
            List<StackScript> list = await _linodeClient.StackScript.Get();

            // Assert
            Assert.True(list.Count > 0);
        }


        [Fact]
        public async Task GetOneTest()
        {
            // Arrange

            // Act
            StackScript stackScript = await _linodeClient.StackScript.Get(1326542);

            // Assert
            Assert.True(stackScript.Id > 0);
        }

        [Fact]
        public async Task CreateTest()
        {
            // Arrange
            string label = $"Super-StackScript-{Guid.NewGuid()}";
            List<string> listImages = new List<string> { "linode/debian10", "linode/debian11", "linode/debian12" };
            string script = "#!/bin/bash\n" +
                            "# Updates the packages\n" +
                            "DEBIAN_FRONTEND=noninteractive apt-get update && DEBIAN_FRONTEND=noninteractive apt-get -y upgrade\n" +
                            "# Tools\n" +
                            "apt install curl -y\n" +
                            "apt install wget -y\n" +
                            "apt install unzip -y\n" +
                            "apt install nginx -y\n" +
                            "apt install nano -y";
            string description = "This its an example";
            string revNote = "check (LJChuello)";
            bool isPublic = true;

            // Act
            StackScript stackScript = await _linodeClient.StackScript.Create(
                label,
                listImages,
                script,
                revNote: revNote,
                description: description,
                isPublic: isPublic);

            // Assert
            Assert.True(stackScript.Id > 0);
        }

        [Fact]
        public async Task UpdateTest()
        {
            // Arrange
            StackScript stackScript = await _linodeClient.StackScript.Get(1326542);
            stackScript.Label = $"new-name-{Guid.NewGuid()}";

            // Act
            stackScript = await _linodeClient.StackScript.Update(stackScript);

            // Assert
            Assert.True(stackScript.Id > 0);
        }

        [Fact]
        public async Task DeleteObjTest()
        {
            // Arrange
            StackScript stackScript = await _linodeClient.StackScript.Get(1326552);

            // Act
            await _linodeClient.StackScript.Delete(stackScript);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public async Task DeleteIdTest()
        {
            // Arrange
            StackScript stackScript = await _linodeClient.StackScript.Get(1326557);

            // Act
            await _linodeClient.StackScript.Delete(stackScript.Id);

            // Assert
            Assert.True(true);
        }
    }
}
