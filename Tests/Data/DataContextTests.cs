using BlazorFinance.Server.Data;
using BlazorFinance.Shared.Entities;
using LiteDB;
using Xunit;

namespace BlazorFinance.Server.Tests.Data
{
    public class DataContextTests : IDisposable
    {
        private readonly string _testDatabasePath;

        public DataContextTests()
        {
            // Use a unique temporary database for each test
            _testDatabasePath = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.db");
        }

        public void Dispose()
        {
            // Clean up the test database after each test
            if (File.Exists(_testDatabasePath)){
                File.Delete(_testDatabasePath);
            }
        }

        #region Create Tests

        [Fact]
        public async Task Create_WithValidEntity_ReturnsNonNullBsonValue()
        {
            // Arrange
            var entity = new TestEntity { Id = 0, Name = "Test Entity" };
            var context = new DataContext<TestEntity>(_testDatabasePath);

            // Act
            var result = await context.Create(entity);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsInt32 || result.IsInt64 || result.IsGuid || result.IsObjectId);
        }

        [Fact]
        public async Task Create_WithValidEntity_EntityCanBeRetrieved()
        {
            // Arrange
            var entity = new TestEntity { Id = 0, Name = "Test Entity" };
            var context = new DataContext<TestEntity>(_testDatabasePath);

            // Act
            await context.Create(entity);
            var retrieved = await context.Read();

            // Assert
            Assert.NotEmpty(retrieved);
            Assert.Single(retrieved);
            Assert.Equal(entity.Name, retrieved.First().Name);
        }

        [Fact]
        public async Task Create_WithNullEntity_ThrowsApplicationException()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);

            // Act & Assert
            await Assert.ThrowsAsync<ApplicationException>(() => context.Create(null!));
        }

        [Fact]
        public async Task Create_MultipleEntities_AllAreInserted()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);
            var entities = new List<TestEntity>
            {
                new TestEntity { Id = 0, Name = "Entity 1" },
                new TestEntity { Id = 0, Name = "Entity 2" },
                new TestEntity { Id = 0, Name = "Entity 3" }
            };

            // Act
            foreach (var entity in entities)
            {
                await context.Create(entity);
            }
            var retrieved = await context.Read();

            // Assert
            Assert.Equal(3, retrieved.Count);
        }

        #endregion

        #region Read Tests

        [Fact]
        public async Task Read_WithValidId_ReturnsCorrectEntity()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);
            var entity = new TestEntity { Id = 0, Name = "Test Entity" };
            var createdId = await context.Create(entity);

            // Act
            var retrieved = await context.Read((int)createdId);

            // Assert
            Assert.NotNull(retrieved);
            Assert.Equal(entity.Name, retrieved.Name);
        }

        [Fact]
        public async Task Read_WithInvalidId_ReturnsNull()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);

            // Act
            var retrieved = await context.Read(9999);

            // Assert
            Assert.Null(retrieved);
        }

        [Fact]
        public async Task Read_NoParameters_ReturnsAllEntities()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);
            var entities = new List<TestEntity>
            {
                new TestEntity { Id = 0, Name = "Entity 1" },
                new TestEntity { Id = 0, Name = "Entity 2" }
            };

            foreach (var entity in entities)
            {
                await context.Create(entity);
            }

            // Act
            var retrieved = await context.Read();

            // Assert
            Assert.Equal(2, retrieved.Count);
        }

        [Fact]
        public async Task Read_NoParameters_EmptyDatabase_ReturnsEmptyList()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);

            // Act
            var retrieved = await context.Read();

            // Assert
            Assert.Empty(retrieved);
        }

        [Fact]
        public async Task Read_WithBsonExpression_ReturnsFilteredEntities()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);
            var entities = new List<TestEntity>
            {
                new TestEntity { Id = 0, Name = "Entity 1", Value = 100 },
                new TestEntity { Id = 0, Name = "Entity 2", Value = 200 }
            };

            foreach (var entity in entities)
            {
                await context.Create(entity);
            }

            var expression = BsonExpression.Create("$.Value > 150");

            // Act
            var retrieved = await context.Read(expression);

            // Assert
            Assert.Single(retrieved);
            Assert.Equal(200, retrieved.First().Value);
        }

        [Fact]
        public async Task Read_WithLambdaPredicate_ReturnsFilteredEntities()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);
            var entities = new List<TestEntity>
            {
                new TestEntity { Id = 0, Name = "Entity 1", Value = 100 },
                new TestEntity { Id = 0, Name = "Entity 2", Value = 200 }
            };

            foreach (var entity in entities)
            {
                await context.Create(entity);
            }

            // Act
            var retrieved = await context.Read(e => e.Value > 150);

            // Assert
            Assert.Single(retrieved);
            Assert.Equal(200, retrieved.First().Value);
        }

        [Fact]
        public async Task Read_WithLambdaPredicateAndProperties_ReturnsFilteredEntities()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);
            var entities = new List<TestEntity>
            {
                new TestEntity { Id = 0, Name = "Entity 1", Value = 100 },
                new TestEntity { Id = 0, Name = "Entity 2", Value = 200 }
            };

            foreach (var entity in entities)
            {
                await context.Create(entity);
            }

            // Act
            var retrieved = await context.Read(e => e.Value > 150, new string[] { });

            // Assert
            Assert.Single(retrieved);
            Assert.Equal(200, retrieved.First().Value);
        }

        #endregion

        #region Update Tests

        [Fact]
        public async Task Update_WithValidEntity_ReturnsTrue()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);
            var entity = new TestEntity { Id = 0, Name = "Original" };
            var bsonId = await context.Create(entity);
            entity.Id = (int)bsonId;
            entity.Name = "Updated";

            // Act
            var result = await context.Update(entity);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Update_WithValidEntity_EntityIsUpdated()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);
            var entity = new TestEntity { Id = 0, Name = "Original" };
            var bsonId = await context.Create(entity);
            entity.Id = (int)bsonId;
            entity.Name = "Updated";

            // Act
            await context.Update(entity);
            var retrieved = await context.Read(entity.Id);

            // Assert
            Assert.Equal("Updated", retrieved.Name);
        }

        [Fact]
        public async Task Update_MultipleEntities_ReturnsCorrectCount()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);
            var entities = new List<TestEntity>
            {
                new TestEntity { Id = 0, Name = "Entity 1" },
                new TestEntity { Id = 0, Name = "Entity 2" }
            };

            var createdIds = new List<int>();
            foreach (var entity in entities)
            {
                var id = await context.Create(entity);
                createdIds.Add((int)id);
            }

            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Id = createdIds[i];
                entities[i].Name = $"Updated {i}";
            }

            // Act
            var result = await context.Update(entities);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public async Task Update_MultipleEntities_AllAreUpdated()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);
            var entities = new List<TestEntity>
            {
                new TestEntity { Id = 0, Name = "Entity 1" },
                new TestEntity { Id = 0, Name = "Entity 2" }
            };

            var createdIds = new List<int>();
            foreach (var entity in entities)
            {
                var id = await context.Create(entity);
                createdIds.Add((int)id);
            }

            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Id = createdIds[i];
                entities[i].Name = $"Updated {i}";
            }

            // Act
            await context.Update(entities);
            var retrieved = await context.Read();

            // Assert
            Assert.All(retrieved, e => Assert.StartsWith("Updated", e.Name));
        }

        #endregion

        #region Upsert Tests

        [Fact]
        public async Task Upsert_WithNewEntity_InsertsEntity()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);
            var entity = new TestEntity { Id = 0, Name = "New Entity" };

            // Act
            var result = await context.Upsert(entity);

            // Assert
            Assert.True(result);
            var retrieved = await context.Read();
            Assert.Single(retrieved);
        }

        [Fact]
        public async Task Upsert_WithExistingEntity_UpdatesEntity()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);
            var entity = new TestEntity { Id = 0, Name = "Original" };
            var bsonId = await context.Create(entity);
            entity.Id = (int)bsonId;
            entity.Name = "Upserted";

            // Act
            var result = await context.Upsert(entity);

            // Assert
            var retrieved = await context.Read(entity.Id);
            Assert.Equal("Upserted", retrieved.Name);
        }

        #endregion

        #region Delete Tests

        [Fact]
        public async Task Delete_WithValidId_ReturnsTrue()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);
            var entity = new TestEntity { Id = 0, Name = "Entity to Delete" };
            var bsonId = await context.Create(entity);

            // Act
            var result = await context.Delete(bsonId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Delete_WithValidId_EntityIsDeleted()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);
            var entity = new TestEntity { Id = 0, Name = "Entity to Delete" };
            var bsonId = await context.Create(entity);

            // Act
            await context.Delete(bsonId);
            var retrieved = await context.Read();

            // Assert
            Assert.Empty(retrieved);
        }

        [Fact]
        public async Task Delete_WithInvalidId_ReturnsFalse()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);
            var invalidId = new BsonValue(9999);

            // Act
            var result = await context.Delete(invalidId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task Delete_MultipleEntities_OnlySpecifiedIsDeleted()
        {
            // Arrange
            var context = new DataContext<TestEntity>(_testDatabasePath);
            var entity1 = new TestEntity { Id = 0, Name = "Entity 1" };
            var entity2 = new TestEntity { Id = 0, Name = "Entity 2" };

            var id1 = await context.Create(entity1);
            await context.Create(entity2);

            // Act
            await context.Delete(id1);
            var retrieved = await context.Read();

            // Assert
            Assert.Single(retrieved);
            Assert.Equal("Entity 2", retrieved.First().Name);
        }

        #endregion
    }

    // Test entity implementation
    public class TestEntity : IEntity
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Value { get; set; }
    }
}