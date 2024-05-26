package com.example.myapplication3.db

import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.OnConflictStrategy
import androidx.room.Query
import androidx.room.Transaction
import androidx.room.Update
import kotlinx.coroutines.flow.Flow

@Dao
interface EntitiesDao {

    @Query("SELECT * FROM $ENTITY_TABLE_NAME")
    fun getEntities(): Flow<List<EntityEntity>>

    @Query("SELECT * FROM $ENTITY_TABLE_NAME WHERE id = :entityId")
    fun getEntityById(entityId: Long): Flow<List<EntityEntity>>

    @Query("SELECT * FROM $ENTITY_TABLE_NAME")
    suspend fun getEntitiesList(): List<EntityEntity>

    @Insert(onConflict = OnConflictStrategy.REPLACE)
    suspend fun createEntity(entity: EntityEntity)

    @Insert(onConflict = OnConflictStrategy.REPLACE)
    suspend fun insertAll(entities: List<EntityEntity>)

    @Update
    suspend fun updateEntity(entity: EntityEntity)

    @Delete
    suspend fun deleteEntity(entity: EntityEntity)

    @Query("DELETE FROM $ENTITY_TABLE_NAME")
    suspend fun deleteAll()

    @Transaction
    suspend fun reset(entities: List<EntityEntity>) {
        deleteAll()
        insertAll(entities)
    }
}
