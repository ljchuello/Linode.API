using Linode.Api.Objets.SshKey;

namespace Linode.Api.Tests
{
    public class SshKeyTest
    {
        private readonly LinodeClient _linodeClient = new LinodeClient(File.ReadAllText("D:\\Linode.Api.txt"));

        [Fact]
        public async Task GetAllTest()
        {
            // Arrange

            // Act
            List<SshKey> list = await _linodeClient.SshKey.Get();

            // Assert
            Assert.True(list.Count > 0);
        }

        [Fact]
        public async Task GetOneTest()
        {
            // Arrange
            List<SshKey> list = await _linodeClient.SshKey.Get();

            // Act
            SshKey sshKey = await _linodeClient.SshKey.Get(list[0].Id);

            // Assert
            Assert.True(list.Count > 0);
        }

        [Fact]
        public async Task CreateTest()
        {
            // Arrange
            SshKeyGenerator.SshKeyGenerator sshKeyGenerator = new SshKeyGenerator.SshKeyGenerator(2048);
            string label = $"name-{Guid.NewGuid()}";
            string pubKey = sshKeyGenerator.ToRfcPublicKey($"{Guid.NewGuid()}");

            // Act
            SshKey sshKey = await _linodeClient.SshKey.Create(label, pubKey);

            // Assert
            Assert.True(sshKey.Id > 0);
        }
    }
}